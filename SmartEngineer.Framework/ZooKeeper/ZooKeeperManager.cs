using apache = org.apache.zookeeper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Framework.ZooKeeper
{
    public class ZooKeeperManager : IDisposable
    {
        private ZooKeeperManager() { }
        public static readonly ZooKeeperManager Instance = new ZooKeeperManager();
        const int sessionTimeout = 4000;

        public Dictionary<String, apache.ZooKeeper> MappedZooKeepers { get; set; } = new Dictionary<string, apache.ZooKeeper>();

        public async Task<apache.ZooKeeper> Get(String connStr)
        {
            apache.ZooKeeper zk = null;
            bool isExists = MappedZooKeepers.ContainsKey(connStr);
            if (isExists)
            {
                zk = MappedZooKeepers[connStr];
                var zkState = zk.getState();
                if (zkState == apache.ZooKeeper.States.CLOSED
                    ||
                    zkState == apache.ZooKeeper.States.NOT_CONNECTED
                    )
                {
                    await Remove(connStr);
                    zk = new apache.ZooKeeper(connStr, sessionTimeout, NoneWatcher.Instance);
                    MappedZooKeepers.Add(connStr, zk);
                }
                return zk;
            }
            zk = new apache.ZooKeeper(connStr, sessionTimeout, NoneWatcher.Instance);
            MappedZooKeepers.Add(connStr, zk);
            return zk;
        }

        public async Task<bool> Remove(String connStr)
        {
            bool isExists = MappedZooKeepers.ContainsKey(connStr);
            if (!isExists)
            {
                return true;
            }
            var zk = MappedZooKeepers[connStr];
            await zk.closeAsync();
            return MappedZooKeepers.Remove(connStr);
        }

        public async void Dispose()
        {
            foreach (var zk in MappedZooKeepers.Values)
            {
                await zk.closeAsync();
            }
            MappedZooKeepers.Clear();
        }
    }

    public class NoneWatcher : apache.Watcher
    {
        public static readonly NoneWatcher Instance = new NoneWatcher();
        private NoneWatcher() { }
        public override Task process(apache.WatchedEvent @event)
        {
            // return Task.CompletedTask;
            return null;
        }
    }
}
