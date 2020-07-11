using System;
using System.Collections.Generic;

namespace AM.Common.GeoLocation
{
    /// <summary>
    /// Represents a unit of distance.
    /// </summary>
    public struct GeoDistanceUnit
    {
        /// <summary>
        /// Represenst the Meter unit.
        /// </summary>
        public static readonly GeoDistanceUnit Meter;

        /// <summary>
        /// Represents the Foot unit.
        /// </summary>
        public static readonly GeoDistanceUnit Foot;

        /// <summary>
        /// Represents the Kilometer unit.
        /// </summary>
        public static readonly GeoDistanceUnit Kilometer;

        /// <summary>
        /// Represents the Mile unit.
        /// </summary>
        public static readonly GeoDistanceUnit Mile;

        private static readonly IDictionary<Units, double> unitConversionMapFromMeters = new Dictionary<Units, double>();

        private readonly Units unit;

        static GeoDistanceUnit()
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

            Meter = new GeoDistanceUnit(Units.Meter, unitConversionMapFromMeters[Units.Meter]);
            Foot = new GeoDistanceUnit(Units.Foot, unitConversionMapFromMeters[Units.Foot]);
            Kilometer = new GeoDistanceUnit(Units.Kilometer, unitConversionMapFromMeters[Units.Kilometer]);
            Mile = new GeoDistanceUnit(Units.Mile, unitConversionMapFromMeters[Units.Mile]);
        }

        /// <summary>
        /// Gets the conversion factor.
        /// </summary>
        public double ConversionFactor { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="GeoDistanceUnit"/> type, given the supported distance unit-type and the conversion factor, from meters.
        /// </summary>
        /// <param name="unit">The <see cref="Units"/> representing the distnace unit.</param>
        /// <param name="conversionFactor">The conversion factor of a single value of unit from meter.</param>
        private GeoDistanceUnit(Units unit, double conversionFactor)
        {
            this.unit = unit;
            this.ConversionFactor = conversionFactor;
        }

        public static bool operator ==(GeoDistanceUnit item1, GeoDistanceUnit item2)
        {
            return item1.unit == item2.unit;
        }

        public static bool operator !=(GeoDistanceUnit item1, GeoDistanceUnit item2)
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

            if (obj.GetType() != typeof(GeoDistanceUnit))
            {
                throw new ArgumentException("Invalid type");
            }

            return (GeoDistanceUnit)obj == this;
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
