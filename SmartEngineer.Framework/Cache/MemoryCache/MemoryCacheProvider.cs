using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace SmartEngineer.Framework.Cache
{
    public sealed class MemoryCacheProvider : ICacheProvider
    {
        private static readonly Object _locker = new object();
        // Gets a reference to the default MemoryCache instance. 
        private static ObjectCache cache = MemoryCache.Default;
        private CacheItemPolicy policy = null;
        private CacheEntryRemovedCallback callback = null;
        private TimeSpan? slidingExpiration = null;
        private DateTime? absoluteExpiration = null;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="properties">Initial parameters</param>
        public void Initialize(IDictionary properties)
        {
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public object Get(string key)
        {
            return cache[key] as Object;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public object Get(string key, Func<object> cachePopulate)
        {
            object value = null;
            if (cache[key] == null)
            {
                lock (_locker)
                {
                    if (cache[key] == null)
                    {
                        var item = new CacheItem(key, cachePopulate());
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                        cache.Add(item, policy);
                    }
                }
            }

            value = cache[key] as Object;

            OnGet?.Invoke(this, new CacheActionEventArgs(key, value));

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
            return Get(key) as T;
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
            return Get(key, cachePopulate) as T;
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
            var policy = CreatePolicy(slidingExpiration, DateTime.Now.AddMinutes(cacheDuration));
            cache.Add(key, objectToCache, policy);
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
            cache.Remove(key);
        }

        /// <summary>
        /// Clears all stored objects from memory.
        /// </summary>
        public void ClearAll()
        {
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        public bool Exists(string key)
        {
            return cache.Contains(key);
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

        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }
    }
}
