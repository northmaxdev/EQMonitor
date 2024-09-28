namespace EQMonitor.Core.Model
{
    public interface IEarthquakeDataset
    {
        public Earthquake? Strongest { get; }
        public Earthquake? Weakest { get; }
        public Earthquake? Latest { get; }
        public Earthquake? Earliest { get; }

        /*
         * TODO: Average magnitude property
         * If implemented, should it be a nullable double? I.e., 0.0 or null magnitude for empty datasets?
         */
    }
}
