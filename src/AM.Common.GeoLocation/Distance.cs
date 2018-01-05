using System;

namespace AM.Common.Validation
{
    /// <summary>
    /// Represents distance in unit-agnostic way.
    /// </summary>
    public struct Distance
    {
        private Unit unitOfLength;
        private double value;

        /// <summary>
        /// Gets the <see cref="Unit"/> the distance <see cref="Value"/> is represented in.
        /// </summary>
        public Unit UnitOfLength => this.unitOfLength;

        /// <summary>
        /// Gets the distance value, in the units specified through <see cref="UnitOfLength"/> units.
        /// </summary>
        public double Value => this.value;

        /// <summary>
        /// Creates a new instance of <see cref="Distance"/> type.
        /// </summary>
        /// <param name="value">The value in the units specified through the <see cref="unit"/> parameter.</param>
        /// <param name="unit">The unit the <see cref="value"/> is specified in.</param>
        public Distance(double value, Unit unit)
        {
            this.value = value;
            this.unitOfLength = unit;
        }

        /// <summary>
        /// Creates a new <see cref="Distance"/> instance with the same value as current instance, converted into the specified <see cref="unit"/> unit.
        /// </summary>
        /// <param name="unit">The <see cref="Unit"/> to convert the distance value to.</param>
        /// <returns></returns>
        public Distance Convert(Unit unit)
        {
            Distance result;
            if (unit == this.UnitOfLength)
            {
                result = this;
            }
            else
            {
                result = new Distance(this.Value * this.UnitOfLength.ConversionFactor / unit.ConversionFactor, unit);
            }

            return result;
        }

        public static bool operator <=(Distance distance1, Distance distance2)
        {
            Distance comparee = distance2.Convert(distance1.UnitOfLength);

            return distance1.Value <= comparee.Value;
        }

        public static bool operator >=(Distance distance1, Distance distance2)
        {
            Distance comparee = distance2.Convert(distance1.UnitOfLength);

            return distance1.Value >= comparee.Value;
        }

        public static bool operator >(Distance distance1, Distance distance2)
        {
            Distance comparee = distance2.Convert(distance1.UnitOfLength);
            return distance1.Value > comparee.Value;
        }

        public static bool operator <(Distance distance1, Distance distance2)
        {
            Distance comparee = distance2.Convert(distance1.UnitOfLength);
            return distance1.Value < comparee.Value;
        }

        public static bool operator ==(Distance distance1, Distance distance2)
        {
            return distance1.Equals(distance2);
        }

        public static bool operator !=(Distance distance1, Distance distance2)
        {
            return !distance1.Equals(distance2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (obj.GetType() != typeof(Distance))
            {
                throw new ArgumentException("Invalid argument type");
            }

            return (Distance)obj == this;
        }

        public bool Equals(Distance distance)
        {
            Distance comparee = distance.Convert(this.UnitOfLength);

            return this.Value == comparee.Value;
        }

        public override int GetHashCode()
        {
            return this.Convert(Unit.Meter).Value.GetHashCode();
        }
    }
}
