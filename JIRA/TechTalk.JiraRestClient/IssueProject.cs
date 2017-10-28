using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTalk.JiraRestClient
{
    public class IssueProject
    {
        public string id { get; set; }        
        public string key { get; set; }
        public string name { get; set; }
        public string self { get; set; }
    }
}
