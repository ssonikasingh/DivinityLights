using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Caching;

namespace SoviTech.Common.CacheHelper.Providers
{
    public class InMemoryCacheProvider : CacheProvider
    {
        private static ObjectCache _client;

        /// <summary>
        /// Default Expiration Time In MilliSeconds
        /// </summary>
        public override int DefaultExpirationTimeInMilliSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Is Concurrency Supported
        /// </summary>
        public override bool IsConcurrencySupported
        {
            get { return true; }
        }

        /// <summary>
        /// CacheName : Not implemented
        /// </summary>
        public override string CacheName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="config"></param>
        public override void Initialize(string providerName, NameValueCollection config)
        {
            if (null == config)
            {
                throw new ArgumentNullException("config");
            }

            base.Initialize(providerName, config);

            // Load configuration data.            
            DefaultExpirationTimeInMilliSeconds =
                Convert.ToInt32(config["defaultExpirationTimeInMS"] ?? "60000");

            bool init;
            bool.TryParse(config["initialize"], out init);

            if (init)
            {
                _client = MemoryCache.Default;
            }

        }

        /// <summary>
        /// Add value to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Add(string key, object value)
        {
            var policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.NotRemovable;
            return _client.Add(key, value, policy);
        }

        /// <summary>
        /// Add value to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public override bool Add(string key, object value, TimeSpan timeout)
        {
            var policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;
            policy.AbsoluteExpiration = DateTimeOffset.Now.Add(timeout);
            return _client.Add(key, value, policy);
        }

        /// <summary>
        /// Add value to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="useDefaultExpiration"></param>
        /// <returns></returns>
        public override bool Add(string key, object value, bool useDefaultExpiration)
        {
            if (!useDefaultExpiration)
                return Add(key, value);

            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default,
                AbsoluteExpiration = DateTimeOffset.Now.AddMilliseconds(DefaultExpirationTimeInMilliSeconds)
            };
            return _client.Add(key, value, policy);
        }

        /// <summary>
        /// Add value to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ttlInMilliSeconds"></param>
        /// <returns></returns>
        public override bool Add(string key, object value, int ttlInMilliSeconds)
        {
            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default,
                AbsoluteExpiration = DateTimeOffset.Now.AddMilliseconds(ttlInMilliSeconds)
            };
            return _client.Add(key, value, policy);
        }

        /// <summary>
        /// Get value from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object Get(string key)
        {
            return _client.Get(key);
        }

        /// <summary>
        /// Get value from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T Get<T>(string key)
        {
            return (T)_client.Get(key);
        }

        /// <summary>
        /// Get value from cache
        /// </summary>
        /// <param name="keys"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns></returns>
        public override IDictionary<string, object> Get(params string[] keys)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update value in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Put(string key, object value)
        {
            var policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.NotRemovable;
            _client.Set(key, value, policy);
            return true;
        }

        /// <summary>
        /// Update value in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public override bool Put(string key, object value, TimeSpan timeout)
        {
            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default,
                AbsoluteExpiration = DateTimeOffset.Now.Add(timeout)
            };
            _client.Set(key, value, policy);
            return true;
        }

        /// <summary>
        /// Remove value from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool Remove(string key)
        {
            _client.Remove(key);
            return true;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
