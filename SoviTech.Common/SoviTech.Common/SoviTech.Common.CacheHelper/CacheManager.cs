using SoviTech.Common.Contracts;

namespace SoviTech.Common.CacheHelper
{
    public class CacheManager : ICacheManager
    {
        static readonly CacheProvider CacheProvider = CacheFactory.GetCacheProvider();

        /// <summary>
        /// Gets the data from cache.
        /// </summary>
        /// <param name="key">data corresponding to this key will be searched </param>
        /// <returns>cached data object</returns>
        public object GetData(string key)
        {
            object returnValue = null;
            try
            {
                returnValue = CacheProvider.Get(key);
            }
            catch
            {
                //supress error and return null
            }
            return returnValue;
        }

        /// <summary>
        /// Puts the data in cache.
        /// </summary>
        /// <param name="key">data object key</param>
        /// <param name="obj">data object to be cached</param>
        public void PutData(string key, object obj)
        {
            if (obj != null && !string.IsNullOrWhiteSpace(key))
            {
                try
                {
                    CacheProvider.Put(key, obj);
                }
                catch
                {
                    //Supress error is no key found
                }
            }
        }
    }
}
