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
        int GetNewIssueCount(DateTime from, DateTime to);

        [OperationContract]
        int GetResolvedIssueCount(DateTime from, DateTime to);

        [OperationContract]
        int GetProductionBugCount(DateTime from, DateTime to);

        //[OperationContract]
        //int GetProductionBugCount();

        [OperationContract]
        int GetTotalTimeSpent(string subTaskKey, DateTime from, DateTime to);

        //[OperationContract]
        //int GetTotalTimeSpent(int category, DateTime from, DateTime to);
    }
}
