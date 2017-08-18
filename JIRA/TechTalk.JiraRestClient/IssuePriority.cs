using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class IssuePriority
    {
        public int id { 
            get
            {
                /// Low - https://accelaeng.atlassian.net/rest/api/2/priority/8
                /// High - https://accelaeng.atlassian.net/rest/api/2/priority/7
                /// Medium - https://accelaeng.atlassian.net/rest/api/2/priority/6
                /// Trivial - https://accelaeng.atlassian.net/rest/api/2/priority/5
                /// Minor - https://accelaeng.atlassian.net/rest/api/2/priority/4
                /// Major - https://accelaeng.atlassian.net/rest/api/2/priority/3
                /// Critical - https://accelaeng.atlassian.net/rest/api/2/priority/2
                /// Blocker - https://accelaeng.atlassian.net/rest/api/2/priority/1
                if("Low" == name) return 8;
                else if ("High" == name) return 7;
                else if ("Medium" == name) return 6;
                else if ("Trivial" == name) return 5;
                else if ("Minor" == name) return 4;
                else if ("Major" == name) return 3;
                else if ("Critical" == name) return 2;
                else if ("Blocker" == name) return 1;
                return 0;
            }
            set{ }
        }
        public string name { get; set; }
        public string iconUrl { get; set; }
        public string self { get; set; }
    }
}
