using SmartEngineer.Core.Model.Common;
using System;

namespace SmartEngineer.Core.DAOs
{
    public interface IIDStoreDAO<T> : IBaseDAO<T>
        where T : IDStore
    {
        int Update(T entity, long lastNumber, DateTime lastTime);
    }
}
