using System;
using System.Collections.Generic;

namespace SoviTech.Common.CacheHelper.Providers
{
    public class NCacheProvider : CacheProvider
    {
        //TODO: Implementation pending
        public override int DefaultExpirationTimeInMilliSeconds
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

        public override bool IsConcurrencySupported
        {
            get { throw new NotImplementedException(); }
        }

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

        public override bool Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public override bool Add(string key, object value, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public override bool Add(string key, object value, bool useDefaultExpiration)
        {
            throw new NotImplementedException();
        }

        public override bool Add(string key, object value, int ttlInMilliSeconds)
        {
            throw new NotImplementedException();
        }

        public override object Get(string key)
        {
            throw new NotImplementedException();
        }

        public override T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public override IDictionary<string, object> Get(params string[] keys)
        {
            throw new NotImplementedException();
        }

        public override bool Put(string key, object value)
        {
            throw new NotImplementedException();
        }

        public override bool Put(string key, object value, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
