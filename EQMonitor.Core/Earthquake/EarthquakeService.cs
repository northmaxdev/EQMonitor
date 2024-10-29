using System.Text.Json;
using EQMonitor.Core.Location;
using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;

namespace EQMonitor.Core.Earthquake;

public sealed class EarthquakeService(HttpClient httpClient)
{
    public enum TimePeriod
    {
        LastHour,
        LastDay,
        LastWeek,
        LastMonth
    }

    private const string BaseUrl = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary";

    public IEnumerable<EarthquakeModel> GetData(TimePeriod timePeriod)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, CreateUri(timePeriod));
        HttpResponseMessage response = httpClient.Send(httpRequest);
        response.EnsureSuccessStatusCode();

        Stream json = response.Content.ReadAsStream();
        FeatureCollection dto = JsonSerializer.Deserialize<FeatureCollection>(json) ?? throw new NullReferenceException("DTO is null, bro");

        return ParseDto(dto);
    }

    private static string CreateUri(TimePeriod timePeriod)
    {
        var endpoint = timePeriod switch
        {
            TimePeriod.LastHour => "all_hour",
            TimePeriod.LastDay => "all_day",
            TimePeriod.LastWeek => "all_week",
            TimePeriod.LastMonth => "all_month",
            _ => throw new ArgumentOutOfRangeException(nameof(timePeriod), timePeriod, null)
        };
        return $"{BaseUrl}/{endpoint}.geojson";
    }

    // https://geojson.org/
    // https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    // All type casts in this method should be safe because they're based specifically on the USGS response docs,
    // and not the general GeoJSON spec.
    private static IEnumerable<EarthquakeModel> ParseDto(FeatureCollection dto)
    {
        foreach (Feature feature in dto.Features)
        {
            IDictionary<string, object> properties = feature.Properties;

            // The USGS docs don't actually specify nullability for this property,
            // but JsonElement.GetString() may return null and LocationModel.Description permits nulls, so why bother?
            string? placeDescription = ((JsonElement)properties["place"]).GetString();
            Point point = (Point)feature.Geometry;
            IPosition coordinates = point.Coordinates;
            var geoPointModel = new GeoPointModel(coordinates.Longitude, coordinates.Latitude);
            var locationModel = new LocationModel(geoPointModel, placeDescription);

            double magnitude = ((JsonElement)properties["mag"]).GetDouble();

            long occurrenceUnixTimeInMillis = ((JsonElement)properties["time"]).GetInt64();
            DateTimeOffset occurrenceTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(occurrenceUnixTimeInMillis);

            yield return new EarthquakeModel(locationModel, magnitude, occurrenceTimestamp);
        }
    }
}
