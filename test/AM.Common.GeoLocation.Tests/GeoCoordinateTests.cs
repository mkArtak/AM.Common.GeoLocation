using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AM.Common.Validation.Tests
{
    public class GeoCoordinateTests
    {
        [Fact]
        public void Equals_ReturnsTrueForSameDistances()
        {
            Distance d1 = new Distance(20, Unit.Foot);
            Distance d2 = new Distance(20, Unit.Foot);

            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void EqualityOperator_ReturnsTrueForSameDistances()
        {
            Distance d1 = new Distance(20, Unit.Foot);
            Distance d2 = new Distance(20, Unit.Foot);

            Assert.True(d1 == d2);
        }

        [Fact]
        public void InequalityOperator_ReturnsFalseForSameDistance()
        {
            Distance d1 = new Distance(20, Unit.Foot);
            Distance d2 = new Distance(20, Unit.Foot);

            Assert.False(d1 != d2);
        }

        [Fact]
        public void InequalityOperator_ReturnsTrueForUnequalDistance()
        {
            Distance d1 = new Distance(21, Unit.Foot);
            Distance d2 = new Distance(20, Unit.Foot);

            Assert.True(d1 != d2);
        }
    }
}
