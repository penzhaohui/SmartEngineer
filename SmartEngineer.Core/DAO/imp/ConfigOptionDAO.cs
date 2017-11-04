using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class ConfigOptionDAO<T> : BaseDAO<T>, IConfigOptionDAO<T>
       where T : ConfigOption
    {
        public override string TableName
        {
            get
            {
                return "admin_ConfigOption";
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
