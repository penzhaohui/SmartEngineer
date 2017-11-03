using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    /// <summary>
    /// https://accelaeng.atlassian.net/rest/api/2/priority/10000 - None
    /// </summary>
    public class IssuePriority
    {
        public string id { get; set; }
        public string name { get; set; }
        public string iconUrl { get; set; }
        public string self { get; set; }
    }
}
