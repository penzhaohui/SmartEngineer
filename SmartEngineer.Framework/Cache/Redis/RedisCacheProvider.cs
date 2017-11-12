using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;

namespace SmartEngineer.Framework.Cache.Redis
{
    public sealed class RedisCacheProvider : ICacheProvider
    {
        private String connStr;
        private ConnectionMultiplexer redis;
        private int databaseId = 0;
        private IDatabase cacheDB { get { return redis.GetDatabase(databaseId); } }
        private String prefix;

        public void Initialize(IDictionary properties)
        {
            connStr = properties["ConnectionString"]?.ToString();
            if (String.IsNullOrEmpty(connStr))
            {
                throw new Exception("Cache.Redis.ConnectionString string can't empty.");
            }

            String databaseIdStr = properties["DatabaseId"]?.ToString();
            if (String.IsNullOrEmpty(databaseIdStr))
            {
                throw new Exception("Cache.Redis.DatabaseId string can't empty.");
            }
            else
            {
                if (!Int32.TryParse(databaseIdStr, out databaseId))
                {
                    throw new Exception("Cache.Redis.DatabaseId string is not int.");
                }
            }
            prefix = properties["Prefix"]?.ToString();
            if (String.IsNullOrEmpty(prefix))
            {
                throw new Exception("Cache.Redis.Prefix string can't empty.");
            }

            redis = RedisManager.Instance.GetRedis(connStr);
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public object Get(string key)
        {
            string cacheStr = cacheDB.StringGet(key);
            if (String.IsNullOrEmpty(cacheStr)) { return null; }
            return JsonConvert.DeserializeObject(cacheStr);
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public object Get(string key, Func<object> cachePopulate)
        {
            object value = Get(key);
            if (value == null)
            {
                value = cachePopulate();
            }

            return value;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public T Get<T>(string key) where T : class
        {
            string cacheStr = cacheDB.StringGet(key);
            if (String.IsNullOrEmpty(cacheStr)) { return null; }
            return JsonConvert.DeserializeObject<T>(cacheStr);
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="cachePopulate">The populate function of cached item</param>
        /// <returns>Cached item as type</returns>
        public T Get<T>(string key, Func<T> cachePopulate) where T : class
        {
            T value = Get<T>(key);
            if (value == null)
            {
                value = cachePopulate();
            }

            return value;
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        public void Add(object objectToCache, string key, int cacheDuration)
        {
            string cacheStr = JsonConvert.SerializeObject(objectToCache);
            cacheDB.StringSet(key, cacheStr);
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        public void Add<T>(T objectToCache, string key, int cacheDuration) where T : class
        {
            Add(objectToCache, key, cacheDuration);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public void Remove(string key)
        {
            cacheDB.KeyDelete(key);
        }

        /// <summary>
        /// Clears all stored objects from memory.
        /// </summary>
        public void ClearAll()
        {
            var serverEndPoint = redis.GetEndPoints()[0];
            IServer servier = redis.GetServer(serverEndPoint);
            var keys = servier.Keys(databaseId, pattern: $"{prefix}*");
            foreach (string key in keys)
            {
                cacheDB.KeyDelete(key);
            }
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        public bool Exists(string key)
        {
            return cacheDB.KeyExists(key);
        }

        /// <summary>
        /// Occurs when an item was retrieved from the cache.
        /// <para>The event will only get triggered on cache hit. Misses do not trigger!</para>
        /// </summary>
        public event EventHandler<CacheActionEventArgs> OnGet;

        /// <summary>
        /// Occurs when an item was put into the cache.
        /// </summary>
        public event EventHandler<CacheActionEventArgs> OnPut;

        /// <summary>
        /// Occurs when an item was successfully removed from the cache.
        /// </summary>
        public event EventHandler<CacheActionEventArgs> OnRemove;
    }
}
