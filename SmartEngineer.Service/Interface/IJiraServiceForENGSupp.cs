using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IJiraServiceForENGSupp
    {
        [OperationContract]
        List<JiraIssue> GetIssuesByLabels(List<string> labels);

        [OperationContract]
        List<string> GetPendingCaseList();

        [OperationContract]
        List<JiraIssue> GetIssuesByStatuses(List<string> statuses);

        [OperationContract]
        List<JiraIssue> GetIssuesByCaseNos(List<string> caseNOs);

        [OperationContract]
        bool ImportCaseNOs(List<string> caseNOs);

        [OperationContract]
        bool ImportCaseComments(List<string> caseNOs);

        [OperationContract]
        bool SyncIssueStatus(List<string> caseNOs);

        [OperationContract]
        bool SyncSalesforceCaseToJiraIssue(List<string> caseNOs);

        [OperationContract]
        List<string> GetNewIssues(DateTime from, DateTime to);

        [OperationContract]
        List<string> GetResolvedIssues(DateTime from, DateTime to);

        [OperationContract]
        List<string> GetProductionBugs();

        [OperationContract]
        int GetTotalTimeSpent(string subTaskKey, DateTime from, DateTime to);
    }
}
