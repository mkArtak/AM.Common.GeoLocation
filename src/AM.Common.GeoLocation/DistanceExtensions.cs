using System;

namespace AM.Common.GeoLocation
{
    /// <summary>
    /// Encapsulates extension methods targeting <see cref="GeoCoordinate"/> type.
    /// </summary>
    public static class DistanceExtensions
    {
        /// <summary>
        /// Calculates the distance between two coordinates.
        /// </summary>
        /// <param name="location1">The source coordinate - to calculate the distance from.</param>
        /// <param name="location2">The destination coordinate - to calculate the distance to.</param>
        /// <returns>The <see cref="Distance"/> between two coordinates.</returns>
        public static Distance DistanceTo(this GeoCoordinate location1, GeoCoordinate location2)
        {
            Distance result;
            if (location1 == location2)
            {
                result = new Distance(0, GeoDistanceUnit.Foot);
            }
            else
            {
                double baseRad = Math.PI * location1.Latitude / 180;
                double targetRad = Math.PI * location2.Latitude / 180;
                double theta = location1.Longitude - location2.Longitude;
                double thetaRad = Math.PI * theta / 180;

                double dist = Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) * Math.Cos(targetRad) * Math.Cos(thetaRad);
                dist = Math.Acos(dist);

                dist = dist * 180 / Math.PI;
                dist = dist * 60 * 1.1515;
                result = new Distance(dist, GeoDistanceUnit.Mile);
            }

            return result;
        }
    }
}
