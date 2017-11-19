using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections;

namespace SmartEngineer.Framework.Cache
{
    public sealed class MemcachedProvider : ICacheProvider
    {
        private static readonly MemcachedClient Cache = new MemcachedClient();

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
            return Cache.Get(key);
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public object Get(string key, Func<object> cachePopulate)
        {
            return Cache.Get(key);
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public T Get<T>(string key) where T : class
        {
            return Cache.Get(key) as T;
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
            return Cache.Get(key) as T;
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
            Cache.Store(StoreMode.Set, key, objectToCache, DateTime.Now.AddMinutes(cacheDuration));
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
            Cache.Store(StoreMode.Set, key, objectToCache, DateTime.Now.AddMinutes(cacheDuration));
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Clears all stored objects from memory.
        /// </summary>
        public void ClearAll()
        {
            Cache.FlushAll();
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        public bool Exists(string key)
        {
            return Cache.Get(key) != null;
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
