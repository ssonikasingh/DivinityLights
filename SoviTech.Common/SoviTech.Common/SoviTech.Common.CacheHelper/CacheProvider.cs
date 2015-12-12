using System;
using System.Collections.Generic;
using SoviTech.Common.Config;

namespace SoviTech.Common.CacheHelper
{
    /// <summary>
    /// Base class for cache provider
    /// </summary>
    public abstract class CacheProvider : ProviderBase
    {
        /// <summary>
        /// Gets or sets the default expiration time in milli seconds.
        /// </summary>
        /// <value>
        /// The default expiration time in milli seconds.
        /// </value>
        public abstract int DefaultExpirationTimeInMilliSeconds { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is concurrency supported.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is concurrency supported; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsConcurrencySupported { get; }

        /// <summary>
        /// Gets or sets the name of the cache.
        /// </summary>
        /// <value>
        /// The name of the cache.
        /// </value>
        public abstract string CacheName { get; set; }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>success : true or false</returns>
        public abstract bool Add(string key, object value);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>success : true or false</returns>
        public abstract bool Add(string key, object value, TimeSpan timeout);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="useDefaultExpiration">if set to <c>true</c> [use default expiration].</param>
        /// <returns>success : true or false</returns>
        public abstract bool Add(string key, object value, bool useDefaultExpiration);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="ttlInMilliSeconds">The TTL in milli seconds.</param>
        /// <returns>success : true or false</returns>
        public abstract bool Add(string key, object value, int ttlInMilliSeconds);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The cached object</returns>
        public abstract object Get(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The cached object</returns>
        public abstract T Get<T>(string key);

        /// <summary>
        /// Gets the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns>dictionary of cached object</returns>
        public abstract IDictionary<string, object> Get(params string[] keys);

        /// <summary>
        /// Puts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>success : true or false</returns>
        public abstract bool Put(string key, object value);

       /// <summary>
        /// Puts the specified key.
       /// </summary>
       /// <param name="key"></param>
       /// <param name="value"></param>
       /// <param name="timeout"></param>
       /// <returns></returns>
        public abstract bool Put(string key, object value, TimeSpan timeout);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>success : true or false</returns>
        public abstract bool Remove(string key);

        /// <summary>
        /// Removes all.
        /// </summary>
        public abstract void RemoveAll();
    }
}
