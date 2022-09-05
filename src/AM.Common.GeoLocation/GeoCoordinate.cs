using System;

namespace AM.Common.GeoLocation
{
    /// <summary>
    /// Represents a geo location coordinate.
    /// </summary>
    public struct GeoCoordinate : IEquatable<GeoCoordinate>
    {
        /// <summary>
        /// Gets or sets the Latitude value of the coordinate.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude value of the coordinate.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="GeoCoordinate"/> type.
        /// </summary>
        /// <param name="latitude">The latitude value of the geo coordinate.</param>
        /// <param name="longitude">The longitude value of the geo coordinate.</param>
        public GeoCoordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public static bool operator ==(GeoCoordinate coordinateA, GeoCoordinate coordinateB)
        {
            return coordinateA.Equals(coordinateB);
        }

        public static bool operator !=(GeoCoordinate coordinateA, GeoCoordinate coordinateB)
        {
            return !coordinateA.Equals(coordinateB);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException();
            }

            if (obj.GetType() != typeof(GeoCoordinate))
            {
                throw new ArgumentException("Invalid input type");
            }

            return (GeoCoordinate)obj == this;
        }

        public bool Equals(GeoCoordinate coordinate)
        {
            return this.Latitude == coordinate.Latitude && this.Longitude == coordinate.Longitude;
        }

        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }
    }
}
