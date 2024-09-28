namespace EQMonitor.Core.Model
{
    // TODO: Unit tests for equals/hashCode semantics
    public record class Earthquake(Location Location, double Magnitude, DateTimeOffset RegistrationTimestamp);
}
