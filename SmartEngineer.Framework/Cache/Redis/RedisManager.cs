using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEngineer.Framework.Cache.Redis
{
    public class RedisManager
    {
        private IDictionary<String, ConnectionMultiplexer> redises = new Dictionary<String, ConnectionMultiplexer>();
        public static readonly RedisManager Instance = new RedisManager();

        private RedisManager() { }
        
        public ConnectionMultiplexer GetRedis(String connStr)
        {
            if (redises.ContainsKey(connStr))
            {
                return redises[connStr];
            }

            lock (this)
            {
                if (redises.ContainsKey(connStr))
                {
                    return redises[connStr];
                }
                var redis = ConnectionMultiplexer.Connect(connStr);
                redises.Add(connStr, redis);
                return redis;
            }
        }
    }
}
