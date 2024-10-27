namespace EQMonitor.Core.Model;

// TODO: Unit tests for equals/hashCode semantics
public record Location(GeoPoint Coordinates, string? Description);
