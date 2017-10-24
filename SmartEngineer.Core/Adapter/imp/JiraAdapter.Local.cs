using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using System;

namespace SmartEngineer.Core.Adapter
{
    public partial class JiraAdapter : IJiraAdapter
    {
        private static readonly IJiraIssueDAO<IssueInfo> JiraIssueDAO = new JiraIssueDAO<IssueInfo>();

        public bool IsExistsLocalIssue(string jiraKey)
        {
            return JiraIssueDAO.IsExist(new { JiraKey = jiraKey });
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            return JiraIssueDAO.IsExist(new { CaseNumber = caseNo });
        }        

        public bool StoreCaseInfoToLocal(IssueInfo issueInfo)
        {
            IssueInfo entity = JiraIssueDAO.Insert(issueInfo);

            return entity.ID > 0;
        }
    }
}