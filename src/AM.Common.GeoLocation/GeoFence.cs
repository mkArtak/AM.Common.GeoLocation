using System.Collections.Generic;
using System.Threading.Tasks;

namespace AM.Common.GeoLocation
{
    public abstract class GeoFence
    {
        public abstract Task<bool> IsLocationWithinAsync(GeoCoordinate location);

        public abstract IDictionary<string, string> ToSerializableData();
    }
}
