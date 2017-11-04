using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class ConfigDAO<T> : BaseDAO<T>, IConfigDAO<T>
        where T : Config
    {
        public override string TableName
        {
            get
            {
                return "admin_Config";
            }
        }

        public override T Insert(T entity)
        {
            entity.ID = this.NewID();
            base.Insert(entity);

            return entity;
        }
    }
}
