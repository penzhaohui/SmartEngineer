using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class IssueSeverity
    {
        public int id
        {
            get {
                if ("Critical" == name) return 10413;
                else if ("Major" == name) return 10414;
                else if ("Medium" == name) return 10415;
                else if ("Low" == name) return 10416;
                return 0;
            }
            set { }
        }
        public string name { get; set; }
        public string self { get; set; }
    }
}
