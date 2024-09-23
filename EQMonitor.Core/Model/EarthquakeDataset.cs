namespace EQMonitor.Core.Model
{
    /*
     * TODO:
     * 1. Seal class
     *
     * Self-notes:
     * 1. What is more idiomatic in C# for getters of stuff that needs to be computed - getter methods or get-properties?
     * 2. The internal collection should be completely immutable
     * 3. If #2 is satisfied, we only need to compute strongest/weakest/earliest/latest once each
     * 4. Further to #3, we can optimize it to be lazily computed (do not optimize prematurely)
     * 5. Equals/hashCode = yay or nay?
     * 
     * Possible future features:
     * 1. Get earthquake closest to a given location.
     *    This will require us to implement a distance calculation method between 2 locations,
     *    simple variant: aerial distance only, fancy variant: multiple distance options.
     *    Aerial distance could probably be calculated with some simple arithmetic, multiple distance options will probably require API calls.
     */

    public class EarthquakeDataset
    {
        public Earthquake? Strongest { get; }
        public Earthquake? Weakest { get; }
        public Earthquake? Earliest { get; }
        public Earthquake? Latest { get; }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
