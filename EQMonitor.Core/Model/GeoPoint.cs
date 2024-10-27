namespace EQMonitor.Core.Model;

// TODO: Unit tests for equals/hashCode semantics
// Self-note: longitude is X, latitude is Y
public readonly record struct GeoPoint(double Longitude, double Latitude);
