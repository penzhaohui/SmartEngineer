using SmartEngineer.ServiceClient.MemberService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.ServiceClient.Adapters
{
    public interface IMemberAdapter
    {
        #region Tenant Operation
        List<Tenant> GetAllTenants();
        
        Tenant GetTenantInfo(string name);
        
        int UpdateTenant(Tenant tenant);
        
        int CreateTenant(Tenant tenant);

        #endregion

        #region Member Operation
        
        List<Member> GetAllMembers(Member memberSearchCriteria);
        
        int CreateMember(Member member);
        
        int UpdateMember(Member member);
        
        bool ActivateMember(string emailAddress, bool active);
        
        bool ResetPasswrord(string emailAddress);
        
        bool LinkToRoles(string emailAddress, List<string> roleNameList, bool isCancel);
        
        bool LinkToGroups(string emailAddress, List<string> groupNameList, bool isCancel);

        List<int> GetLinkedRoles(string emailAddress);

        List<int> GetLinkedGroups(string emailAddress);

        #endregion

        #region Permission Operation
        #endregion

        List<Role> GetAllRoles();
        List<Group> GetAllGroups();
    }
}
