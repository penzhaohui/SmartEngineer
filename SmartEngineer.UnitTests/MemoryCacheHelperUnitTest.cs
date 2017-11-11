using NUnit.Framework;
using SmartEngineer.Framework.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.UnitTests
{
    [TestFixture()]
    public class MemoryCacheHelperUnitTest
    {
        [Test()]
        public void UnitTest()
        {
            string cacheKey = "person_key";
            Person p = MemoryCacheHelper.FindCacheItem<Person>(cacheKey,
                () =>
                {
                    return new Person() { Id = Guid.NewGuid(), Name = "wolfy" };
                }, new TimeSpan(0, 30, 0));

            if (p != null)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("获取缓存中数据");

            Person p2 = MemoryCacheHelper.FindCacheItem<Person>(cacheKey,
                () =>
                {
                    return new Person() { Id = Guid.NewGuid(), Name = "wolfy" };
                }, new TimeSpan(0, 30, 0));

            if (p2 != null)
            {
                Console.WriteLine(p2.ToString());
            }

            MemoryCacheHelper.RemoveCache(cacheKey);
            Person p3 = MemoryCacheHelper.FindCacheItem<Person>(cacheKey,
               () =>
               {
                   return new Person() { Id = Guid.NewGuid(), Name = "wolfy" };
               }, new TimeSpan(0, 30, 0));

            if (p3 != null)
            {
                Console.WriteLine(p3.ToString());
            }

            Console.Read();
        }


        public class Person
        {
            public Guid Id { set; get; }
            public string Name { set; get; }
            public override string ToString()
            {
                return Id.ToString() + "\t" + Name;
            }
        }
    }
}
