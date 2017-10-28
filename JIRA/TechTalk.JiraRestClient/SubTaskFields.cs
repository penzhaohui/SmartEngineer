using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class SubTaskFields
    {
        public SubTaskFields()
        {
            project = new IssueProject();
            Labels = new List<String>();
        }

        public IssueProject project { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public IssueType IssueType { get; set; }
        public Status Status { get; set; }
        public IssueRef Parent { get; set; }
        public IssuePriority Priority { get; set; }
        public List<String> Labels { get; set; }
        public JiraUser Creator { get; set; }
        public JiraUser Reporter { get; set; }
        public JiraUser Assignee { get; set; }
        public int Timespent { get; set; }
        
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
