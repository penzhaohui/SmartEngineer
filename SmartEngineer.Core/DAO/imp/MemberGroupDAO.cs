using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class MemberGroupDAO<T> : BaseDAO<T>, IMemberGroupDAO<T>
        where T : MemberGroup
    {
        public override string TableName
        {
            get
            {
                return "admin_MemberGroup";
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
