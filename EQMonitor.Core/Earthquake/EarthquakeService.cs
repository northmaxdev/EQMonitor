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

    // TODO: Implement this as async
    public IEnumerable<EarthquakeModel> GetData(TimePeriod timePeriod)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, CreateUri(timePeriod));
        HttpResponseMessage response = httpClient.Send(httpRequest);
        response.EnsureSuccessStatusCode();

        string json = response.Content.ReadAsStringAsync().Result;
        FeatureCollection featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json) ?? throw new NullReferenceException("Something happened bro");

        return ParseDto(featureCollection);
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

    private static IEnumerable<EarthquakeModel> ParseDto(FeatureCollection geoJsonFeatureCollection)
    {
        foreach (Feature feature in geoJsonFeatureCollection.Features)
        {
            IDictionary<string, object> featureProperties = feature.Properties;

            double magnitude = ((JsonElement)featureProperties["mag"]).GetDouble();
            long timestampInMilliseconds = ((JsonElement)featureProperties["time"]).GetInt64();
            string placeDescription = ((JsonElement)featureProperties["place"]).GetString() ?? throw new NullReferenceException("Bro wtf");
            Point point = (Point)feature.Geometry;
            IPosition coordinates = point.Coordinates;

            var geoPointModel = new GeoPointModel(coordinates.Longitude, coordinates.Latitude);
            var locationModel = new LocationModel(geoPointModel, placeDescription);
            DateTimeOffset registrationTimestamp = DateTimeOffset.FromUnixTimeMilliseconds(timestampInMilliseconds);

            yield return new EarthquakeModel(locationModel, magnitude, registrationTimestamp);
        }
    }
}
