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
        List<JiraIssue> GetIssuesByLabels(List<string> labels);

        [OperationContract]
        bool UpdateAssignee(string jiraKey, string assignee);

        [OperationContract]
        bool UpdateAssigneeQA(string jiraKey, string assignee);

        [OperationContract]
        List<JiraIssue> GetUpdatedIssues(DateTime from, DateTime to, List<string> assignees);

        [OperationContract]
        List<JiraWorkLog> GetWorkLogs(string jiraKey);

        //[OperationContract]
        //List<WorkLog> GetWorkLogs(DateTime from, DateTime to, List<string> assignees);

        [OperationContract]
        string GetCaseStudy(string jiraKey, string options);

        [OperationContract]
        List<JiraSubTask> GetSubTasks(string jiraKey);

        [OperationContract]
        bool UpdateSubTasks(string jiraKey, JiraSubTask subTask);

        [OperationContract]
        bool CloseSubTasks(string jiraKey);
    }
}
