using System;
using System.Runtime.Caching;

namespace SmartEngineer.Framework.Cache
{
    /// <summary>
    /// 基于MemoryCache的缓存辅助类
    /// http://www.cnblogs.com/wolf-sun/p/7251343.html
    /// </summary>
    public static class MemoryCacheHelper
    {
        private static readonly Object _locker = new object();

        public static T FindCacheItem<T>(string key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Invalid cache key");
            }
            if (cachePopulate == null)
            {
                throw new ArgumentNullException("cachePopulate");
            }
            if (slidingExpiration == null && absoluteExpiration == null)
            {
                throw new ArgumentException("Either a sliding expiration or absolute must be provided");
            }

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        var item = new CacheItem(key, cachePopulate());
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCache(string key)
        {
            MemoryCache.Default.Remove(key);
        }

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
