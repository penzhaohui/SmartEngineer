using Enyim.Caching;
using Enyim.Caching.Memcached;
using NUnit.Framework;
using SmartEngineer.Framework.Cache;
using System;

namespace SmartEngineer.UnitTests
{
    [TestFixture()]
    public class EnyimMemcachedUnitTests
    {
        [Test()]
        public void MemcachedTest()
        {
            // create a MemcachedClient in your application 
            // you can cache the client in a static variable or just recreate it every time
            MemcachedClient mc = new MemcachedClient();

            // store a string in the cache
            mc.Store(StoreMode.Set, "MyKey", "Hello");

            // retrieve the item from the cache
            Console.WriteLine(mc.Get("MyKey"));

            // store some other items
            mc.Store(StoreMode.Set, "D1", 1234L);
            mc.Store(StoreMode.Set, "D2", DateTime.Now);
            mc.Store(StoreMode.Set, "D3", true);
            mc.Store(StoreMode.Set, "D4", new Product());

            mc.Store(StoreMode.Set, "D5", new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            System.Diagnostics.Debug.WriteLine("D1: {0}", mc.Get("D1"));
            Console.WriteLine("D2: {0}", mc.Get("D2"));
            Console.WriteLine("D3: {0}", mc.Get("D3"));
            Console.WriteLine("D4: {0}", mc.Get("D4"));

            byte[] tmp = mc.Get<byte[]>("D5");

            // delete them from the cache
            mc.Remove("D1");
            mc.Remove("D2");
            mc.Remove("D3");
            mc.Remove("D4");

            // add an item which is valid for 10 mins
            mc.Store(StoreMode.Set, "D4", new Product(), new TimeSpan(0, 10, 0));
            Console.WriteLine("D4: {0}", mc.Get("D4"));
            Console.ReadLine();
        }

        [Test()]
        public void CacheLayerTest()
        {
            CacheLayer.Add<string>("Hello", "MyKey", 10);
            System.Diagnostics.Debug.WriteLine("MyKey: " + CacheLayer.Get<string>("MyKey"));

            CacheLayer.Add<Product>(new Product(), "D1", 10);
            CacheLayer.Add<byte[]>(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, "D2", 10);

            System.Diagnostics.Debug.WriteLine("D1: " + CacheLayer.Get<Product>("D1"));
            System.Diagnostics.Debug.WriteLine("D2: " + CacheLayer.Get<byte[]>("D2"));
        }

        // objects must be serializable to be able to store them in the cache
        [Serializable]
        class Product
        {
            public double Price = 1.24;
            public string Name = "Mineral Water";

            public override string ToString()
            {
                return String.Format("Product {{{0}: {1}}}", this.Name, this.Price);
            }
        }
    }
}
