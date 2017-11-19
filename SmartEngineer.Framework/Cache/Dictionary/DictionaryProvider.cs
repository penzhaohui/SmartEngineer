using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartEngineer.Framework.Cache
{
    public sealed class DictionaryProvider : ICacheProvider
    {
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

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
            object cacheValue = cache[key];
            if (cacheValue == null)
            {
                cacheValue = cachePopulate();
                cache[key] = cacheValue;
            }

            return cacheValue;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public T Get<T>(string key) where T : class
        {
            T cacheValue = cache[key] as T;
            return cacheValue;
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
            T cacheValue = cache[key] as T;
            if (cacheValue == null)
            {
                cacheValue = cachePopulate();
                cache[key] = cacheValue;
            }

            return cache[key] as T;
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
            cache.Add(key, objectToCache);
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
            cache.Add(key, objectToCache);
           
            System.Diagnostics.Debug.WriteLine($"Set key:{key}, count: {(objectToCache as List<string>)?.Count}");
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
            cache.Clear();
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        public bool Exists(string key)
        {
            return cache.ContainsKey(key);
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
