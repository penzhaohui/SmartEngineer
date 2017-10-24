using SmartEngineer.Core.Models;
using System;

namespace SmartEngineer.Core.Adapter
{
    public partial class JiraAdapter : IJiraAdapter
    {
        public bool IsExistsLocalIssue(string jiraKey)
        {
            throw new NotImplementedException();
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            throw new NotImplementedException();
        }        

        public bool StoreCaseInfoToLocal(IssueInfo issueInfo)
        {
            throw new NotImplementedException();
        }
    }
}