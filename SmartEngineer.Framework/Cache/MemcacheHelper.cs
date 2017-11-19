using Autofac;
using CacheManager.Core;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SmartEngineer.Framework.Cache
{
    public class MemcacheHelper
    {
        public static MemcachedClientConfiguration Configuration
        {
            get
            {
                var memConfig = new MemcachedClientConfiguration();
                memConfig.AddServer("localhost", 11211);
                memConfig.AddServer("localhost", 11212);
                memConfig.AddServer("localhost", 11213);
                memConfig.AddServer("localhost", 11214);
                memConfig.AddServer("localhost", 11215);
                return memConfig;
            }
        }

        public static void RegisterMemcacheWithAutofac()
        {
            var client = new MemcachedClient(Configuration);
            var cache = CacheFactory.Build(
                settings =>
                settings.WithMemcachedCacheHandle(client));

            var builder = new ContainerBuilder();
            builder.RegisterInstance(cache).As<ICacheManager<object>>(); ;
        }

        public static void RegisterMemcacheWithMicrosoftUnity()
        {
            var client = new MemcachedClient(Configuration);
            var cache = CacheFactory.Build(
                settings =>
                settings.WithMemcachedCacheHandle(client));

            var container = new UnityContainer();
            container.RegisterType(
                typeof(ICacheManager<>),
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(
                    (c, t, n) => CacheFactory.FromConfiguration(
                        t.GetGenericArguments()[0],
                        ConfigurationBuilder.BuildConfiguration(cfg => cfg.WithDictionaryHandle()))));
        }
    }
}
