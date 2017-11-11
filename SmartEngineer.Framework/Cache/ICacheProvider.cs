using System;
using System.Collections;

namespace SmartEngineer.Framework.Cache
{
    public interface ICacheProvider
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="properties">Initial parameters</param>
        void Initialize(IDictionary properties);

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        object Get(string key);

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        object Get(string key, Func<object> cachePopulate);

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        T Get<T>(string key) where T : class;

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="cachePopulate">The populate function of cached item</param>
        /// <returns>Cached item as type</returns>
        T Get<T>(string key, Func<T> cachePopulate) where T : class;

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        void Add(object objectToCache, string key, int cacheDuration);

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="objectToCache">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheDuration">Duration of the cache.</param>
        void Add<T>(T objectToCache, string key, int cacheDuration) where T : class;

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        void Remove(string key);

        /// <summary>
        /// Clears all stored objects from memory.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>A boolean if the object exists</returns>
        bool Exists(string key);

        /// <summary>
        /// Occurs when an item was retrieved from the cache.
        /// <para>The event will only get triggered on cache hit. Misses do not trigger!</para>
        /// </summary>
        event EventHandler<CacheActionEventArgs> OnGet;

        /// <summary>
        /// Occurs when an item was put into the cache.
        /// </summary>
        event EventHandler<CacheActionEventArgs> OnPut;

        /// <summary>
        /// Occurs when an item was successfully removed from the cache.
        /// </summary>
        event EventHandler<CacheActionEventArgs> OnRemove;
    }
}
