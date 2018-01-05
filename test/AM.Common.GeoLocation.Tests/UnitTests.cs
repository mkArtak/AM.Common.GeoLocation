using Xunit;

namespace AM.Common.Validation.Tests
{
    public class UnitTests
    {
        [Fact]
        public void GetHashCode_ValuesAreDifferentForDifferentTypesOfUnits()
        {
            Unit unit1 = Unit.Kilometer;
            Unit unit2 = Unit.Meter;

            int hashCode1 = unit1.GetHashCode();
            int hashCode2 = unit2.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void GetHashCode_ReturnsConsistentValues()
        {
            int hashCode1 = Unit.Meter.GetHashCode();
            int hashCode2 = Unit.Meter.GetHashCode();

            Assert.Equal(hashCode1, hashCode2);
        }
    }
}
