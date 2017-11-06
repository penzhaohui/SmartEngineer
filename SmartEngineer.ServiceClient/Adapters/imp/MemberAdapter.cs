using log4net;
using SmartEngineer.Common;
using SmartEngineer.Framework.Logger;
using SmartEngineer.ServiceClient.MemberService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Adapters
{
    public class MemberAdapter : IMemberAdapter
    {
        /// <summary>
        /// Logger object.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger(typeof(CaseAdapter));
        private static readonly MemberServiceClient MemberServiceClient = WSFactory.Instance.GetWCFClient<MemberServiceClient, IMemberService>();

        #region Tenant Operation
        public List<Tenant> GetAllTenants()
        {
            List<Tenant> tenants = new List<Tenant>();
            var result = MemberServiceClient.GetAllTenants();
            tenants.AddRange(result);

            return tenants;
        }

        public Tenant GetTenantInfo(string name)
        {
            return MemberServiceClient.GetTenantInfo(name);
        }

        public int UpdateTenant(Tenant tenant)
        {
            return MemberServiceClient.UpdateTenant(tenant);
        }

        public int CreateTenant(Tenant tenant)
        {
            return MemberServiceClient.CreateTenant(tenant);
        }

        #endregion

        #region Member Operation

        public List<Member> GetAllMembers(Member memberSearchCriteria)
        {
            List<Member> members = new List<Member>();
            var result = MemberServiceClient.GetAllMembers(memberSearchCriteria);
            members.AddRange(result);

            return members;
        }

        public int CreateMember(Member member)
        {
            return MemberServiceClient.CreateMember(member);
        }

        public int UpdateMember(Member member)
        {
            return MemberServiceClient.UpdateMember(member);
        }

        public bool ActivateMember(string emailAddress, bool active)
        {
            return MemberServiceClient.ActivateMember(emailAddress, active);
        }

        public bool ResetPasswrord(string emailAddress)
        {
            return MemberServiceClient.ResetPasswrord(emailAddress);
        }

        public bool LinkToRole(string emailAddress, string role, bool isCancel)
        {
            return MemberServiceClient.LinkToRole(emailAddress, role, isCancel);
        }

        public bool LinkToGroup(string emailAddress, string group, bool isCancel)
        {
            return MemberServiceClient.LinkToGroup(emailAddress, group, isCancel);
        }

        #endregion

        #region Permission Operation
        #endregion

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            var result = MemberServiceClient.GetAllRoles();
            roles.AddRange(result);

            return roles;
        }

        public List<Group> GetAllGroups()
        {
            List<Group> groups = new List<Group>();
            var result = MemberServiceClient.GetAllGroups();
            groups.AddRange(result);

            return groups;
        }
    }
}
