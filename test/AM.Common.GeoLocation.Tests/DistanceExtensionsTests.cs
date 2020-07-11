using Xunit;

namespace AM.Common.GeoLocation.Tests
{
    public class DistanceExtensionsTests
    {
        [Theory]
        [InlineData(7, 17)]
        public void DistanceTo_ReturnsZeroForSameCoordinate(long latitude, long longitude)
        {
            GeoCoordinate coordinate1 = new GeoCoordinate(latitude, longitude);
            GeoCoordinate coordinate2 = new GeoCoordinate(latitude, longitude);

            Distance actualDistance = coordinate1.DistanceTo(coordinate2);

            Distance expectedDistance = new Distance(0, GeoDistanceUnit.Meter);

            Assert.Equal(expectedDistance, actualDistance);
        }
    }
}
