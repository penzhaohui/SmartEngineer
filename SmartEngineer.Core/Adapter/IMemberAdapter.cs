using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Core.Adapter
{
    public interface IMemberAdapter
    {
        #region Tenant Operation
        
        List<Tenant> GetAllTenants();

        Tenant GetTenantInfo(string name);

        int SaveTenant(Tenant tenant);

        #endregion

        #region Member Operation

        List<Member> GetAllMembers(Member memberSearchCriteria);

        int SaveMember(Member member);

        bool ActivateMember(string emailAddress, bool active);

        bool ResetPasswrord(string emailAddress);

        bool LinkToRole(string emailAddress, string role, bool isCancel);

        bool LinkToGroup(string emailAddress, string group, bool isCancel);

        #endregion

        #region Role Operation

        List<Role> GetAllRoles();

        #endregion

        #region Group Operation

        List<Group> GetAllGroups();

        #endregion

        #region Permission Operation
        #endregion
    }
}
