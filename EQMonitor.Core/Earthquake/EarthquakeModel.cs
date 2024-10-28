using EQMonitor.Core.Location;

namespace EQMonitor.Core.Earthquake;

public record EarthquakeModel(LocationModel OccurrenceLocation, double Magnitude, DateTimeOffset OccurrenceTimestamp);
