namespace EQMonitor.Core.Model;

public sealed class EarthquakeStats
{
    public Earthquake? Strongest { get; }
    public Earthquake? Weakest { get; }
    public Earthquake? Latest { get; }
    public Earthquake? Earliest { get; }
    public double AverageMagnitude { get; }

    private EarthquakeStats(IEnumerable<Earthquake> dataset)
    {
        // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1851
        IReadOnlyCollection<Earthquake> datasetAsCollection = dataset.ToList();

        Strongest = datasetAsCollection.MaxBy(earthquake => earthquake.Magnitude);
        Weakest = datasetAsCollection.MinBy(earthquake => earthquake.Magnitude);
        Latest = datasetAsCollection.MaxBy(earthquake => earthquake.RegistrationTimestamp);
        Earliest = datasetAsCollection.MinBy(earthquake => earthquake.RegistrationTimestamp);
        AverageMagnitude = datasetAsCollection.Average(earthquake => earthquake.Magnitude);
    }

    // Syntactic sugar for readability
    public static EarthquakeStats From(IEnumerable<Earthquake> dataset)
    {
        return new EarthquakeStats(dataset);
    }
}
