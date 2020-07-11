using System.Threading.Tasks;

namespace AM.Common.GeoLocation
{
    /// <summary>
    /// Represents an abstraction for geo-areas
    /// </summary>
    public interface IGeoFence
    {
        /// <summary>
        /// Checks whether the specified <paramref name="location"/> is within the geo fence.
        /// </summary>
        /// <param name="location">The coordinates of the location to check.</param>
        /// <returns>true, if the location is within the geo fence. false - otherwise.</returns>
        Task<bool> IsLocationWithinAsync(GeoCoordinate location);
    }
}
