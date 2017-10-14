using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SmartEngineer.Service
{
    [ServiceContract]
    public interface IJiraService
    {
        [OperationContract]
        List<IssueInfo> GetIssuesByLabels(List<string> labels);

        [OperationContract]
        bool UpdateAssignee(string jiraKey, string assignee);

        [OperationContract]
        bool UpdateAssigneeQA(string jiraKey, string assignee);

        [OperationContract]
        List<IssueInfo> GetUpdatedIssues(DateTime from, DateTime to, List<string> assignees);

        [OperationContract]
        List<WorkLog> GetWorkLogs(string jiraKey);

        //[OperationContract]
        //List<WorkLog> GetWorkLogs(DateTime from, DateTime to, List<string> assignees);

        [OperationContract]
        string GetCaseStudy(string jiraKey, string options);

        [OperationContract]
        List<SubTask> GetSubTasks(string jiraKey);

        [OperationContract]
        bool UpdateSubTasks(string jiraKey, SubTask subTask);

        [OperationContract]
        bool CloseSubTasks(string jiraKey);
    }
}
