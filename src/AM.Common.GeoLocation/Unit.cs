using System;
using System.Collections.Generic;

namespace AM.Common.Validation
{
    /// <summary>
    /// Represents a unit of distance.
    /// </summary>
    public struct Unit
    {
        /// <summary>
        /// Represenst the Meter unit.
        /// </summary>
        public static Unit Meter;

        /// <summary>
        /// Represents the Foot unit.
        /// </summary>
        public static Unit Foot;

        /// <summary>
        /// Represents the Kilometer unit.
        /// </summary>
        public static Unit Kilometer;

        /// <summary>
        /// Represents the Mile unit.
        /// </summary>
        public static Unit Mile;

        private static IDictionary<Units, double> unitConversionMapFromMeters = new Dictionary<Units, double>();

        private readonly double factor;
        private readonly Units unit;

        static Unit()
        {
            unitConversionMapFromMeters.Add(Units.Millimeter, 0.001);
            unitConversionMapFromMeters.Add(Units.Centimeter, 0.01);
            unitConversionMapFromMeters.Add(Units.Decimeter, 0.1);
            unitConversionMapFromMeters.Add(Units.Foot, 0.3048);
            unitConversionMapFromMeters.Add(Units.Yard, 0.9144);
            unitConversionMapFromMeters.Add(Units.Meter, 1);
            unitConversionMapFromMeters.Add(Units.Kilometer, 1000);
            unitConversionMapFromMeters.Add(Units.Mile, 1609.344);
            unitConversionMapFromMeters.Add(Units.NauticalMile, 1852);

            Meter = new Unit(Units.Meter, unitConversionMapFromMeters[Units.Meter]);
            Foot = new Unit(Units.Foot, unitConversionMapFromMeters[Units.Foot]);
            Kilometer = new Unit(Units.Kilometer, unitConversionMapFromMeters[Units.Kilometer]);
            Mile = new Unit(Units.Mile, unitConversionMapFromMeters[Units.Mile]);
        }

        /// <summary>
        /// Gets the conversion factor.
        /// </summary>
        public double ConversionFactor { get { return this.factor; } }

        /// <summary>
        /// Creates a new instance of <see cref="Unit"/> type, given the supported distance unit-type and the conversion factor, from meters.
        /// </summary>
        /// <param name="unit">The <see cref="Units"/> representing the distnace unit.</param>
        /// <param name="conversionFactor">The conversion factor of a single value of unit from meter.</param>
        private Unit(Units unit, double conversionFactor)
        {
            this.unit = unit;
            this.factor = conversionFactor;
        }

        public static bool operator ==(Unit item1, Unit item2)
        {
            return item1.unit == item2.unit;
        }

        public static bool operator !=(Unit item1, Unit item2)
        {
            return item1.unit != item2.unit;
        }

        public override int GetHashCode()
        {
            return this.unit.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Invalid argument");
            }

            if (obj.GetType() != typeof(Unit))
            {
                throw new ArgumentException("Invalid type");
            }

            return (Unit)obj == this;
        }

        /// <summary>
        /// Represents the supported list of units of distance.
        /// </summary>
        public enum Units
        {
            Millimeter,
            Centimeter,
            Decimeter,
            Foot,
            Yard,
            Meter,
            Kilometer,
            Mile,
            NauticalMile
        }
    }
}
