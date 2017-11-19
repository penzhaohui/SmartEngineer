using System;
using System.Collections.Generic;
using System.Runtime.Caching;

// https://www.codeproject.com/Articles/290935/Using-MemoryCache-in-Net-4-0
namespace SmartEngineer.Framework.Cache
{
    public class SimpleMemoryCache
    {
        // Gets a reference to the default MemoryCache instance. 
        private static ObjectCache cache = MemoryCache.Default;
        private CacheItemPolicy policy = null;
        private CacheEntryRemovedCallback callback = null;

        public void AddToCache(String CacheKeyName, Object CacheItem,
            CachePriority cacheItemPriority = CachePriority.Default, ChangeMonitor monitor = null)
        {
            // 
            callback = new CacheEntryRemovedCallback(this.SimpleCachedItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = (cacheItemPriority == CachePriority.Default) ?
                    CacheItemPriority.Default : CacheItemPriority.NotRemovable;
            //policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.00);
            policy.SlidingExpiration = TimeSpan.FromSeconds(30);
            policy.RemovedCallback = callback;
            if (monitor != null)
            {
                policy.ChangeMonitors.Add(monitor);
            }

            // Add inside cache 
            cache.Set(CacheKeyName, CacheItem, policy);
        }

        public Object GetCachedItem(String CacheKeyName)
        {
            // 
            return cache[CacheKeyName] as Object;
        }

        public void RemoveCachedItem(String CacheKeyName)
        {
            // 
            if (cache.Contains(CacheKeyName))
            {
                cache.Remove(CacheKeyName);
            }
        }

        private void SimpleCachedItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            // Log these values from arguments list 
            String strLog = String.Concat("Reason: ", arguments.RemovedReason.ToString(), "| Key - Name: ", arguments.CacheItem.Key, " | Value - Object: ", arguments.CacheItem.Value.ToString());
        }
    }

    public enum CachePriority
    {
        Default,
        NotRemovable
    }
}
