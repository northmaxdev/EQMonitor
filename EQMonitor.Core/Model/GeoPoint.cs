namespace EQMonitor.Core.Model
{
    // Self-note: longitude is X, latitude is Y
    public readonly record struct GeoPoint(double Longitude, double Latitude);
}
