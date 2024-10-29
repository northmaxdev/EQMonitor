using EQMonitor.Core.Location;

namespace EQMonitor.Core.Earthquake;

public record EarthquakeModel(LocationModel OccurrenceLocation, double Magnitude, DateTimeOffset OccurrenceTimestamp)
{
    public override string ToString()
    {
        return $"{Magnitude:F2} {OccurrenceLocation} at {OccurrenceTimestamp}";
    }
}
