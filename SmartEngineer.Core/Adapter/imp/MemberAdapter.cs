﻿using System;
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
        private static readonly IMemberGroupDAO<MemberGroup> MemberGroupDAO = new MemberGroupDAO<MemberGroup>();
        private static readonly IMemberRoleDAO<MemberRole> MemberRoleDAO = new MemberRoleDAO<MemberRole>();

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

        public bool LinkToGroups(string emailAddress, List<string> groupNameList, bool isCancel)
        {
            var member = MemberDAO.GetEntity(new { EmailAddress = emailAddress });
            if (member == null || member.ID < 0)
            {
                return false;
            }

            foreach (string groupName in groupNameList)
            {
                var group = GroupDAO.GetEntity(new { Name = groupName });
                if (group == null || group.ID < 0)
                {
                    return false;
                }

                var memberGroup = new MemberGroup();
                memberGroup.MemberID = member.ID;
                memberGroup.GroupID = group.ID;
                if (MemberGroupDAO.IsExist(memberGroup))
                {
                    memberGroup.IsActive = isCancel;
                    MemberGroupDAO.Update(memberGroup);
                }
                else
                {
                    memberGroup.IsActive = isCancel;
                    MemberGroupDAO.Insert(memberGroup);
                }
            }

            return true;
        }

        public bool LinkToRoles(string emailAddress, List<string> roleNameList, bool isCancel)
        {
            var member = MemberDAO.GetEntity(new { EmailAddress = emailAddress });
            if (member == null || member.ID < 0)
            {
                return false;
            }

            foreach (string roleName in roleNameList)
            {
                var role = RoleDAO.GetEntity(new { Name = roleName });
                if (role == null || role.ID < 0)
                {
                    return false;
                }

                var memberRole = new MemberRole();
                memberRole.MemberID = member.ID;
                memberRole.RoleID = role.ID;
                if (MemberRoleDAO.IsExist(memberRole))
                {
                    memberRole.IsActive = isCancel;
                    MemberRoleDAO.Update(memberRole);
                }
                else
                {
                    memberRole.IsActive = isCancel;
                    MemberRoleDAO.Insert(memberRole);
                }
            }

            return true;
        }

        public List<int> GetLinkedRoles(string emailAddress)
        {
            var member = MemberDAO.GetEntity(new { EmailAddress = emailAddress });
            if (member == null || member.ID < 0)
            {
                return null;
            }

            var memberRole = new MemberRole();
            memberRole.MemberID = member.ID;
            memberRole.IsActive = true;

            var LinkedRoles = MemberRoleDAO.GetList<MemberRole>(memberRole);
            var LinkedRoleIDs = LinkedRoles.Select(linkedRole => linkedRole.RoleID);
            return LinkedRoleIDs.ToList<int>();
        }

        public List<int> GetLinkedGroups(string emailAddress)
        {
            var member = MemberDAO.GetEntity(new { EmailAddress = emailAddress });
            if (member == null || member.ID < 0)
            {
                return null;
            }

            var memberGroup = new MemberGroup();
            memberGroup.MemberID = member.ID;
            memberGroup.IsActive = true;

            var LinkedGroups = MemberGroupDAO.GetList<MemberGroup>(memberGroup);
            var LinkedGroupIDs = LinkedGroups.Select(linkedGroup => linkedGroup.GroupID);
            return LinkedGroupIDs.ToList<int>();
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
