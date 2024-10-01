namespace EQMonitor.Core.Model
{
    public interface IEarthquakeDataset
    {
        public Earthquake? Strongest { get; }
        public Earthquake? Weakest { get; }
        public Earthquake? Latest { get; }
        public Earthquake? Earliest { get; }
        public double AverageMagnitude { get; }

        /*
         * TODO:
         * Ability to get a subset of the current dataset with some specific criteria, e.g. earthquakes of a single country only
         * (if this is applicable in the geographical sense)
         */
    }
}
