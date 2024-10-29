namespace EQMonitor.Core.Location;

public readonly record struct GeoPointModel(double Longitude, double Latitude)
{
    public override string ToString()
    {
        return $"x: {Longitude}, y: {Latitude}";
    }
}
