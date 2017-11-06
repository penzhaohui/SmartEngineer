using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMemberService" in both code and config file together.
    [ServiceContract]
    public interface IMemberService
    {
        #region Tenant Operation

        [OperationContract]
        List<Tenant> GetAllTenants();

        [OperationContract]
        Tenant GetTenantInfo(string name);

        [OperationContract]
        int UpdateTenant(Tenant tenant);

        [OperationContract]
        int CreateTenant(Tenant tenant);

        #endregion

        #region Member Operation

        [OperationContract]
        List<Member> GetAllMembers(Member memberSearchCriteria);

        [OperationContract]
        int CreateMember(Member member);

        [OperationContract]
        int UpdateMember(Member member);

        [OperationContract]
        bool ActivateMember(string emailAddress, bool active);

        [OperationContract]
        bool ResetPasswrord(string emailAddress);

        [OperationContract]
        bool LinkToRole(string emailAddress, string role, bool isCancel);

        [OperationContract]
        bool LinkToGroup(string emailAddress, string group, bool isCancel);

        #endregion

        #region Permission Operation
        #endregion

        [OperationContract]
        List<Role> GetAllRoles();
        [OperationContract]
        List<Group> GetAllGroups();
    }
}
