using EQMonitor.Core.Location;

namespace EQMonitor.Core.Earthquake;

public record EarthquakeModel(LocationModel OccurenceLocation, double Magnitude, DateTimeOffset RegistrationTimestamp);
