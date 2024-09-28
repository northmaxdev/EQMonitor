namespace EQMonitor.Core.Model
{
    // TODO: Double-check my understanding of "sealed" (compared to Java)
    public sealed class ImmutableEarthquakeDataset : IEarthquakeDataset
    {
        public Earthquake? Strongest => throw new NotImplementedException();

        public Earthquake? Weakest => throw new NotImplementedException();

        public Earthquake? Latest => throw new NotImplementedException();

        public Earthquake? Earliest => throw new NotImplementedException();
    }
}
