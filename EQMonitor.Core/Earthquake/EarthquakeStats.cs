namespace EQMonitor.Core.Earthquake;

public sealed class EarthquakeStats
{
    private EarthquakeStats(IEnumerable<EarthquakeModel> dataset)
    {
        // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1851
        IReadOnlyCollection<EarthquakeModel> datasetAsCollection = dataset.ToList();

        Strongest = datasetAsCollection.MaxBy(earthquake => earthquake.Magnitude);
        Weakest = datasetAsCollection.MinBy(earthquake => earthquake.Magnitude);
        Latest = datasetAsCollection.MaxBy(earthquake => earthquake.RegistrationTimestamp);
        Earliest = datasetAsCollection.MinBy(earthquake => earthquake.RegistrationTimestamp);
        AverageMagnitude = datasetAsCollection.Average(earthquake => earthquake.Magnitude);
    }

    public EarthquakeModel? Strongest { get; }
    public EarthquakeModel? Weakest { get; }
    public EarthquakeModel? Latest { get; }
    public EarthquakeModel? Earliest { get; }
    public double AverageMagnitude { get; }

    // Syntactic sugar for readability
    public static EarthquakeStats From(IEnumerable<EarthquakeModel> dataset)
    {
        return new EarthquakeStats(dataset);
    }
}
