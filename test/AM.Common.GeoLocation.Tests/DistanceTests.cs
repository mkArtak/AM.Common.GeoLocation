using Xunit;

namespace AM.Common.Validation.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void Equals_ReturnsTrueForSameDistance()
        {
            Distance d1 = new Distance(77, Unit.Foot);
            Distance d2 = new Distance(77, Unit.Foot);

            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void Equals_ReturnsFalseForUnequalDistances()
        {
            Distance d1 = new Distance(76, Unit.Foot);
            Distance d2 = new Distance(77, Unit.Foot);

            Assert.False(d1.Equals(d2));
        }

        [Fact]
        public void Equals_ReturnsTrueForSameDistanceOfDifferentUnits()
        {
            Distance d1 = new Distance(10, Unit.Kilometer);
            Distance d2 = new Distance(10000, Unit.Meter);

            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void GreaterThan_ReturnsTrueForBiggerDistance()
        {
            Distance d1 = new Distance(10, Unit.Meter);
            Distance d2 = new Distance(11, Unit.Meter);

            Assert.True(d2 > d1);
        }

        [Fact]
        public void SmallerThan_ReturnsTrueForSmallerDistance()
        {
            Distance d1 = new Distance(10, Unit.Meter);
            Distance d2 = new Distance(11, Unit.Meter);

            Assert.True(d1 < d2);
        }
    }
}
