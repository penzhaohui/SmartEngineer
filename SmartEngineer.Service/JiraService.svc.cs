using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmartEngineer.Core.Models;

namespace SmartEngineer.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JiraService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JiraService.svc or JiraService.svc.cs at the Solution Explorer and start debugging.
    public class JiraService : IJiraService
    {
        public bool CloseSubTasks(string jiraKey)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public string GetCaseStudy(string jiraKey, string options)
        {
            throw new NotImplementedException();
        }

        public List<IssueInfo> GetIssuesByLabels(List<string> labels)
        {
            throw new NotImplementedException();
        }

        public List<SubTask> GetSubTasks(string jiraKey)
        {
            throw new NotImplementedException();
        }

        public List<IssueInfo> GetUpdatedIssues(DateTime from, DateTime to, List<string> assignees)
        {
            throw new NotImplementedException();
        }

        public List<WorkLog> GetWorkLogs(string jiraKey)
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

        public bool UpdateSubTasks(string jiraKey, SubTask subTask)
        {
            throw new NotImplementedException();
        }
    }
}
