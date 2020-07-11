using Xunit;

namespace AM.Common.GeoLocation.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void Equals_ReturnsTrueForSameDistance()
        {
            Distance d1 = new Distance(77, GeoDistanceUnit.Foot);
            Distance d2 = new Distance(77, GeoDistanceUnit.Foot);

            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void Equals_ReturnsFalseForUnequalDistances()
        {
            Distance d1 = new Distance(76, GeoDistanceUnit.Foot);
            Distance d2 = new Distance(77, GeoDistanceUnit.Foot);

            Assert.False(d1.Equals(d2));
        }

        [Fact]
        public void Equals_ReturnsTrueForSameDistanceOfDifferentUnits()
        {
            Distance d1 = new Distance(10, GeoDistanceUnit.Kilometer);
            Distance d2 = new Distance(10000, GeoDistanceUnit.Meter);

            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void GreaterThan_ReturnsTrueForBiggerDistance()
        {
            Distance d1 = new Distance(10, GeoDistanceUnit.Meter);
            Distance d2 = new Distance(11, GeoDistanceUnit.Meter);

            Assert.True(d2 > d1);
        }

        [Fact]
        public void SmallerThan_ReturnsTrueForSmallerDistance()
        {
            Distance d1 = new Distance(10, GeoDistanceUnit.Meter);
            Distance d2 = new Distance(11, GeoDistanceUnit.Meter);

            Assert.True(d1 < d2);
        }
    }
}
