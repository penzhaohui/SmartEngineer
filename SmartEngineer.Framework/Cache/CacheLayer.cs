using System;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace SmartEngineer.Framework.Cache
{
    public class CacheLayer
    {
        private static readonly MemcachedClient Cache = new MemcachedClient();

        
        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)Cache.Get(key);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        public static void Add<T>(T objectToCache, string key, int cacheDuration) where T : class
        {
            Cache.Store(StoreMode.Set, key, objectToCache, DateTime.Now.AddMinutes(cacheDuration));
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        public static void Add(object objectToCache, string key, int cacheDuration)
        {
            Cache.Store(StoreMode.Set, key, objectToCache, DateTime.Now.AddMinutes(cacheDuration));
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Clears all stored objects from memory.
        /// </summary>
        public static void ClearAll()
        {
            Cache.FlushAll();
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        public static bool Exists(string key)
        {
            return Cache.Get(key) != null;
        }
    }
}
