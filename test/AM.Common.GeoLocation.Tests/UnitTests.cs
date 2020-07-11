using Xunit;

namespace AM.Common.GeoLocation.Tests
{
    public class UnitTests
    {
        [Fact]
        public void GetHashCode_ValuesAreDifferentForDifferentTypesOfUnits()
        {
            GeoDistanceUnit unit1 = GeoDistanceUnit.Kilometer;
            GeoDistanceUnit unit2 = GeoDistanceUnit.Meter;

            int hashCode1 = unit1.GetHashCode();
            int hashCode2 = unit2.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void GetHashCode_ReturnsConsistentValues()
        {
            int hashCode1 = GeoDistanceUnit.Meter.GetHashCode();
            int hashCode2 = GeoDistanceUnit.Meter.GetHashCode();

            Assert.Equal(hashCode1, hashCode2);
        }
    }
}
