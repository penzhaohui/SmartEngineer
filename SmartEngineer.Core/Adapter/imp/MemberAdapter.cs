using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEngineer.Core.Models;
using SmartEngineer.Framework.Logger;
using log4net;
using SmartEngineer.Core.DAOs;

namespace SmartEngineer.Core.Adapter
{
    public class MemberAdapter : IMemberAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(MemberAdapter));
        private static readonly ITenantDAO<Tenant> TenantDAO = new TenantDAO<Tenant>();
        private static readonly IMemberDAO<Member> MemberDAO = new MemberDAO<Member>();
        private static readonly IAccountDAO<Account> AccountDAO = new AccountDAO<Account>();
        private static readonly IRoleDAO<Role> RoleDAO = new RoleDAO<Role>();
        private static readonly IGroupDAO<Group> GroupDAO = new GroupDAO<Group>();

        #region Tenant Operation

        public List<Tenant> GetAllTenants()
        {
            var result = TenantDAO.GetList<Tenant>(null);
            return result.ToList<Tenant>();
        }

        public Tenant GetTenantInfo(string name)
        {
            return TenantDAO.GetEntity(new { Name = name });
        }

        public int SaveTenant(Tenant tenant)
        {
            int ID = 0;
            if (!TenantDAO.IsExist(tenant))
            {
                var entity = TenantDAO.Insert(tenant);
                ID = entity.ID;
            }
            else
            {
                ID = TenantDAO.Update(tenant);
            }

            return ID;
        }

        #endregion

        #region Member Operation

        public List<Member> GetAllMembers(Member memberSearchCriteria)
        {
            var result = MemberDAO.GetList<Member>(memberSearchCriteria);
            return result.ToList<Member>();
        }

        public int SaveMember(Member member)
        {
            var account = AccountDAO.GetEntity(new { EmailAddress = member.EmailAddress });
            if (account != null)
            {
                member.AccountID = account.ID;
            }

            int ID = 0;
            if (!MemberDAO.IsExist(member))
            {
                var entity = MemberDAO.Insert(member);
                ID = entity.ID;
            }
            else
            {
                ID = MemberDAO.Update(member);
            }

            return ID;
        }

        public bool ActivateMember(string emailAddress, bool active)
        {
            var member = MemberDAO.GetEntity(new { EmailAddress = emailAddress });
            if (member != null)
            {
                member.IsActive = active;
                MemberDAO.Update(member);

                var account = AccountDAO.GetEntity(new { ID = member.AccountID });
                if (account != null)
                {
                    AccountDAO.Update(account);
                }

                return true;
            }

            return false;
        }

        public bool ResetPasswrord(string emailAddress)
        {
            var account = AccountDAO.GetEntity(new { EmailAddress = emailAddress });
            if (account != null)
            {
                account.Password = "123456";
                AccountDAO.Update(account);
                return true;
            }

            return false;
        }

        public bool LinkToGroup(string emailAddress, string group, bool isCancel)
        {
            throw new NotImplementedException();
        }

        public bool LinkToRole(string emailAddress, string role, bool isCancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Role Operation

        public List<Role> GetAllRoles()
        {
            var result = RoleDAO.GetList<Role>(null);

            return result.ToList<Role>();
        }

        #endregion

        #region Group Operation

        public List<Group> GetAllGroups()
        {
            var result = GroupDAO.GetList<Group>(null);

            return result.ToList<Group>();
        }

        #endregion
    }
}
