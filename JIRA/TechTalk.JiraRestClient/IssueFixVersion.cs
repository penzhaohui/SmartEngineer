using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class IssueFixVersion
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public DateTime releaseDate { get; set; }
        public string self { get; set; }
    }
}
