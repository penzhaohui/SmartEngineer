using SmartEngineer.Core.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;
using Xunit;

namespace SmartEngineer.Core.Test.Adapter
{
    public class JiraAdapterTest
    {
        private static IJiraAdapter JiraAdapter = new JiraAdapter();

        [Fact]
        public void GetSubTask()
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = "ENGSUPP-15259";
            issueRef.id = "104953";

            var subTaskList = JiraAdapter.PullSubTasks(issueRef, "peter.peng@missionsky.com", "peter.peng");

            if (subTaskList != null)
            {
                foreach (SubTask subTask in subTaskList)
                {
                }
            }
        }
    }
}
