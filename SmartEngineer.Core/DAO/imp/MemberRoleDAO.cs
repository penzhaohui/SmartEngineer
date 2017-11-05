using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class MemberRoleDAO<T> : BaseDAO<T>, IMemberRoleDAO<T>
        where T : MemberRole
    {
        public override string TableName
        {
            get
            {
                return "admin_MemberRole";
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
