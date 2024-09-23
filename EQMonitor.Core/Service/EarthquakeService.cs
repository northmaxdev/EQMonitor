namespace EQMonitor.Core.Service
{
    /*
     * Self-notes:
     * 1. Fully immutable, as always
     * 2. No equals/hashCode - disable them explicitly unless C# has well-defined conventions for this
     * 3. The sole purpose of this service is to fetch an EarthquakeDataset, with multiple period options:
     *    3.1 Last day
     *    3.2 Last week
     *    3.3 Last month
     *    3.4 Last year
     *    3.5 Specific day (date)
     *    3.6 Specific month (year+month)
     *    3.7 Specific year
     *    Some of these options may not be possible via the API.
     */
    internal class EarthquakeService
    {
    }
}
