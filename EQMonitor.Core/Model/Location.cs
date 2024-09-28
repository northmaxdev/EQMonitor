namespace EQMonitor.Core.Model
{
    // TODO: Unit tests for equals/hashCode semantics
    public record class Location(GeoPoint Coordinates, string? Description);
}
