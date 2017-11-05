using SmartEngineer.Core.Models;

namespace SmartEngineer.Core.DAOs
{
    public class MemberDAO<T> : BaseDAO<T>, IMemberDAO<T>
        where T : Member
    {
        public override string TableName
        {
            get
            {
                return "admin_Member";
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
