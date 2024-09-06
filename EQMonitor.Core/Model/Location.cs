namespace EQMonitor.Core.Model
{
    public record class Location(GeoPoint Coordinates, string? Description);
}
