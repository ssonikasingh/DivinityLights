using SoviTech.Common.Config;
using System;

namespace SoviTech.Common.CacheHelper
{
    /// <summary>
    /// Cache Factory
    /// </summary>
    public static class CacheFactory
    {
        private static readonly ProviderRepository<CacheProvider> CacheProviders =
            new ProviderRepository<CacheProvider>("cacheProvider");

        /// <summary>
        /// Gets the cache provider.
        /// </summary>
        /// <param name="cacheProviderName">Name of the cache provider.</param>
        /// <returns>the cache provider</returns>
        public static T GetCacheProvider<T>(string cacheProviderName)
        {
            if (string.IsNullOrWhiteSpace(cacheProviderName))
            {
                cacheProviderName = CacheProviders.DefaultProviderName;
            }
            CacheProvider provider = CacheProviders.Providers[cacheProviderName];
            return (T) Convert.ChangeType(provider, typeof (T));
        }

        /// <summary>
        /// Gets the cache provider.
        /// </summary>
        /// <param name="cacheProviderName"></param>
        /// <returns></returns>
        public static CacheProvider GetCacheProvider(string cacheProviderName)
        {
            if (string.IsNullOrWhiteSpace(cacheProviderName))
            {
                cacheProviderName = CacheProviders.DefaultProviderName;
            }
            var provider = CacheProviders.Providers[cacheProviderName];
            return provider;
        }

        /// <summary>
        /// Gets the cache provider.
        /// </summary>
        /// <returns>The cache provider</returns>
        public static T GetCacheProvider<T>()
        {
            var provider = CacheProviders.Provider;
            return (T) Convert.ChangeType(provider, typeof (T));
        }

        /// <summary>
        /// Gets the cache provider.
        /// </summary>
        /// <returns></returns>
        public static CacheProvider GetCacheProvider()
        {
            return CacheProviders.Provider;
        }
    }
}
