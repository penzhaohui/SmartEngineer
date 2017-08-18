using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechTalk.JiraRestClient
{
    public class SubTask
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public SubTaskFields fields { get; set; }
    }
}
