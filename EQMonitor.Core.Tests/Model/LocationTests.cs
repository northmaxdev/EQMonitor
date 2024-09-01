using EQMonitor.Core.Model;

namespace EQMonitor.Core.Tests.Model
{
    [TestFixture]
    public class LocationTests
    {
        private GeoPoint EiffelTowerCoordinates { get; init; } = new GeoPoint
        {
            Latitude = 48.8583,
            Longitude = 2.2945
        };

        [Test]
        public void RejectsBlankDescription([Values("", " ", "\t", "\n")] string description) // Can't use string.Empty
        {
            Assert.Throws<ArgumentException>(() => new Location(EiffelTowerCoordinates, description));
        }

        [Test]
        public void AcceptsNonBlankDescription()
        {
            Assert.DoesNotThrow(() => new Location(EiffelTowerCoordinates, "Eiffel Tower"));
        }
    }
}
