using System.Threading.Tasks;

namespace AM.Common.GeoLocation
{
    /// <summary>
    /// Represents a geo-fence which has a shape of a circle, determined by its center location and the radius.
    /// </summary>
    public class CircularGeoFence : IGeoFence
    {
        public const string RadiusPropertyName = nameof(Radius);
        public const string LatitudePropertyName = nameof(GeoCoordinate.Latitude);
        public const string LongitudePropertyName = nameof(GeoCoordinate.Longitude);

        public CircularGeoFence(double latitude, double longitude, double radiusInMiles) : this(new GeoCoordinate(latitude, longitude), new Distance(radiusInMiles, GeoDistanceUnit.Mile))
        {
        }

        public CircularGeoFence(GeoCoordinate centerLocation, Distance radius)
        {
            this.CenterLocation = centerLocation;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the location of the center
        /// </summary>
        public GeoCoordinate CenterLocation { get; set; }

        /// <summary>
        /// Gets or sets the radius of the fence.
        /// </summary>
        public Distance Radius { get; set; }

        public Task<bool> IsLocationWithinAsync(GeoCoordinate location)
        {
            TaskCompletionSource<bool> result = new TaskCompletionSource<bool>();

            Distance distance = location.DistanceTo(this.CenterLocation);
            result.SetResult(distance <= this.Radius);

            return result.Task;
        }
    }
}
