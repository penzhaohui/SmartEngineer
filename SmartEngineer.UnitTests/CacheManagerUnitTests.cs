using NUnit.Framework;
using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

// Visual Studio 2017 优雅单元测试
// http://jingyan.baidu.com/article/6b97984dd9adb31ca2b0bfe0.html
namespace SmartEngineer.UnitTests
{
    [TestFixture()]
    public class CacheManagerUnitTests
    {
        [Test()]
        public void EventTest()
        {
            var cache = CacheFactory.Build<string>(s => s.WithDictionaryHandle());
            cache.OnAdd += (sender, args) => Console.WriteLine("Added " + args.Key);
            cache.OnGet += (sender, args) => Console.WriteLine("Got " + args.Key);
            cache.OnRemove += (sender, args) => Console.WriteLine("Removed " + args.Key);

            cache.Add("key", "value");
            var val = cache.Get("key");
            cache.Remove("key");
        }

        [Test()]
        public void UnityInjectioTest()
        {
            var container = new UnityContainer();
            container.RegisterType<ICacheManager<object>>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory((c) => CacheFactory.Build(s => s.WithDictionaryHandle())));

            container.RegisterType<UnityInjectionExampleTarget>();

            // resolving the test target object should also resolve the cache instance
            var target = container.Resolve<UnityInjectionExampleTarget>();
            target.PutSomethingIntoTheCache();

            // our cache manager instance should still be there so should the object we added in the
            // previous step.
            var checkTarget = container.Resolve<UnityInjectionExampleTarget>();
            checkTarget.GetSomething();
        }

        public class UnityInjectionExampleTarget
        {
            private ICacheManager<object> _cache;

            public UnityInjectionExampleTarget(ICacheManager<object> cache)
            {
                _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            }

            public void GetSomething()
            {
                var value = _cache.Get("myKey");
                var x = value;
                if (value == null)
                {
                    throw new InvalidOperationException();
                }
            }

            public void PutSomethingIntoTheCache()
            {
                _cache.Put("myKey", "something");
            }
        }

        [Test()]
        public void UnityInjectionAdvanceTest()
        {
            var container = new UnityContainer();
            container.RegisterType(
                typeof(ICacheManager<>),
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(
                    (c, t, n) => CacheFactory.FromConfiguration(
                        t.GetGenericArguments()[0],
                        ConfigurationBuilder.BuildConfiguration(cfg => cfg.WithDictionaryHandle()))));

            var stringCache = container.Resolve<ICacheManager<string>>();

            // testing if we create a singleton instance per type, every Resolve of the same type should return the same instance!
            var stringCacheB = container.Resolve<ICacheManager<string>>();
            stringCache.Put("key", "something");

            var intCache = container.Resolve<ICacheManager<int>>();
            var intCacheB = container.Resolve<ICacheManager<int>>();
            intCache.Put("key", 22);

            var boolCache = container.Resolve<ICacheManager<bool>>();
            var boolCacheB = container.Resolve<ICacheManager<bool>>();
            boolCache.Put("key", false);

            Console.WriteLine("Value type is: " + stringCache.GetType().GetGenericArguments()[0].Name + " test value: " + stringCacheB["key"]);
            Console.WriteLine("Value type is: " + intCache.GetType().GetGenericArguments()[0].Name + " test value: " + intCacheB["key"]);
            Console.WriteLine("Value type is: " + boolCache.GetType().GetGenericArguments()[0].Name + " test value: " + boolCacheB["key"]);
        }

        [Test()]
        public void CreateCacheInstanceUnitTest()
        {
            var config = new ConfigurationBuilder()
                .WithSystemRuntimeCacheHandle()
                .Build();

            var cache1 = new BaseCacheManager<string>(config);
            var cache2 = CacheFactory.FromConfiguration<string>(config);

            var cache3 = new BaseCacheManager<string>(
               new CacheManagerConfiguration()
                   .Builder
                   .WithSystemRuntimeCacheHandle()
                   .Build());

            var cache4 = CacheFactory.Build<string>(
                p => p.WithSystemRuntimeCacheHandle());
        }

        [Test()]
        public void BuildTest4()
        {
            Assert.Fail();
        }

        [Test()]
        public void BuildTest5()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest2()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest3()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest4()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest5()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest6()
        {
            Assert.Fail();
        }

        [Test()]
        public void FromConfigurationTest7()
        {
            Assert.Fail();
        }
    }
}