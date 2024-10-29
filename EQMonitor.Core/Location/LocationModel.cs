namespace EQMonitor.Core.Location;

public record LocationModel(GeoPointModel Coordinates, string? Description)
{
    public override string ToString()
    {
        return Description ?? Coordinates.ToString();
    }
}
