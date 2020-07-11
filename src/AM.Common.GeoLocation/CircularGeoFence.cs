using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Common.GeoLocation
{
    public class CircularGeoFence : GeoFence
    {
        public const string RadiusPropertyName = nameof(Radius);
        public const string LatitudePropertyName = nameof(GeoCoordinate.Latitude);
        public const string LongitudePropertyName = nameof(GeoCoordinate.Longitude);

        public CircularGeoFence(double latitude, double longitude, double radiusInMiles)
        {
            this.Location = new GeoCoordinate(latitude, longitude);
            this.Radius = new Distance(radiusInMiles, Unit.Mile);
        }

        public GeoCoordinate Location { get; set; }

        public Distance Radius { get; set; }

        public override Task<bool> IsLocationWithinAsync(GeoCoordinate location)
        {
            TaskCompletionSource<bool> result = new TaskCompletionSource<bool>();

            Distance distance = location.DistanceTo(this.Location);
            result.SetResult(distance <= this.Radius);

            return result.Task;
        }

        public override IDictionary<string, string> ToSerializableData()
        {
            IDictionary<string, string> result = new Dictionary<string, string>
            {
                [LatitudePropertyName] = this.Location.Latitude.ToString(),
                [LongitudePropertyName] = this.Location.Longitude.ToString(),
                [RadiusPropertyName] = this.Radius.ToString()
            };
            return result;
        }
    }
}
