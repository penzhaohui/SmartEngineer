using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Framework.Cache
{
    public interface ICacheProvider
    {
        void Initialize(IDictionary properties);
        object this[CacheKey key, Type type]
        {
            get;
            set;
        }
        bool Remove(CacheKey key);
        void Flush();
    }
}
