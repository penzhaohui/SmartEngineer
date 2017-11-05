using SmartEngineer.Core.Adapter;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MemberService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MemberService.svc or MemberService.svc.cs at the Solution Explorer and start debugging.
    public class MemberService : IMemberService
    {
        private static readonly IMemberAdapter MemberAdapter = new MemberAdapter();

        #region Tenant Operation

        public List<Tenant> GetAllTenants()
        {
            return MemberAdapter.GetAllTenants();
        }

        public Tenant GetTenantInfo(string name)
        {
            return MemberAdapter.GetTenantInfo(name);
        }

        public int UpdateTenant(Tenant tenant)
        {
            return MemberAdapter.SaveTenant(tenant);
        }

        public int CreateTenant(Tenant tenant)
        {
            return MemberAdapter.SaveTenant(tenant);
        }        

        #endregion

        #region Member Operation

        public List<Member> GetAllMembers(Member memberSearchCriteria)
        {
            return MemberAdapter.GetAllMembers(memberSearchCriteria);
        }
        public int CreateMember(Member member)
        {
            return MemberAdapter.SaveMember(member);
        }

        public int UpdateMember(Member member)
        {
            return MemberAdapter.SaveMember(member);
        }

        public bool ActivateMember(string emailAddress, bool active)
        {
            return MemberAdapter.ActivateMember(emailAddress, active);
        }

        public bool ResetPasswrord(string emailAddress)
        {
            return MemberAdapter.ResetPasswrord(emailAddress);
        }

        public bool LinkToGroup(string emailAddress, string group, bool isCancel)
        {
            return MemberAdapter.LinkToGroup(emailAddress, group, isCancel);
        }

        public bool LinkToRole(string emailAddress, string role, bool isCancel)
        {
            return MemberAdapter.LinkToRole(emailAddress, role, isCancel);
        }

        #endregion

        public List<Role> GetAllRoles()
        {
            return MemberAdapter.GetAllRoles();
        }

        public List<Group> GetAllGroups()
        {
            return MemberAdapter.GetAllGroups();
        }
    }
}
