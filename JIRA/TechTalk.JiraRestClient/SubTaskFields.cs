using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class SubTaskFields
    {
        public string summary { get; set; }
        public Status status { get; set; }
        public IssuePriority priority { get; set; }
        public IssueType issuetype { get; set; }
    }
}
