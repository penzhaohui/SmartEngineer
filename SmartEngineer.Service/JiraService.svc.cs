using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;

namespace SmartEngineer.Service
{
    public class JiraService : IJiraService
    {
        public JiraService() { }

        public bool CloseSubTasks(string jiraKey)
        {
            throw new NotImplementedException();
        }

        public string GetCaseStudy(string jiraKey, string options)
        {
            throw new NotImplementedException();
        }

        public List<JiraIssue> GetIssuesByLabels(List<string> labels)
        {
            throw new NotImplementedException();
        }

        public List<JiraSubTask> GetSubTasks(string jiraKey)
        {
            throw new NotImplementedException();
        }

        public List<JiraIssue> GetUpdatedIssues(DateTime from, DateTime to, List<string> assignees)
        {
            throw new NotImplementedException();
        }

        public List<JiraWorkLog> GetWorkLogs(string jiraKey)
        {
            throw new NotImplementedException();
        }

        /*
        public List<WorkLog> GetWorkLogs(DateTime from, DateTime to, List<string> assignees)
        {
            throw new NotImplementedException();
        }
        */

        public bool UpdateAssignee(string jiraKey, string assignee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAssigneeQA(string jiraKey, string assignee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSubTasks(string jiraKey, JiraSubTask subTask)
        {
            throw new NotImplementedException();
        }
    }
}
