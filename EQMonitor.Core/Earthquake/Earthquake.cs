using EQMonitor.Core.Location;

namespace EQMonitor.Core.Earthquake;

public record Earthquake(LocationModel OccurenceLocation, double Magnitude, DateTimeOffset RegistrationTimestamp);
