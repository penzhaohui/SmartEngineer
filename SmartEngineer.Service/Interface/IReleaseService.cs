using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IReleaseService
    {
        [OperationContract]
        int SubmitReleaseInfo(ReleaseInfo releaseInfo);

        [OperationContract]
        int GetReleaseInfo(int id);

        [OperationContract]
        bool AddJiraFilter(int id, string url);

        [OperationContract]
        bool AddCodeBanch(int id, string product, string url);

        [OperationContract]
        bool AddTestRail(int id, string testrun, string url);

        [OperationContract]
        List<IssueInfo> GetExistingScopeItems(int id);

        [OperationContract]
        bool SubmitNewScopeItems(string name, List<IssueInfo> items);
    }
}
