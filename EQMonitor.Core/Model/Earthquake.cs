namespace EQMonitor.Core.Model
{
    public record class Earthquake(Location Location, double Magnitude, DateTimeOffset Timing);
}
