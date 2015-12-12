
namespace SoviTech.Common.Contracts
{
    /// <summary>
    /// Interface for Cache Manager
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Gets the data from cache.
        /// </summary>
        /// <param name="key">data corresponding to this key will be searched </param>
        /// <returns>cached data object</returns>
        object GetData(string key);

        /// <summary>
        /// Puts the data in cache.
        /// </summary>
        /// <param name="key">data object key</param>
        /// <param name="obj">data object to be cached</param>
        void PutData(string key, object obj);
    }
}
