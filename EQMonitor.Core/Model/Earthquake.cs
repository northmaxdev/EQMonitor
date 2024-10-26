namespace EQMonitor.Core.Model
{
    // TODO: Unit tests for equals/hashCode semantics
    public record Earthquake(Location Location, double Magnitude, DateTimeOffset RegistrationTimestamp);
}
