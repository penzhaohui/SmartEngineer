using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTalk.JiraRestClient
{
    public class MEOOption
    {
        public int id
        {
            get
            {
                if ("Meets" == value) return 13204;
                else if ("Exceeds" == value) return 13205;
                else if ("Outstanding" == value) return 13206;
                return 0;
            }
            set { }
        }
        public string self { get; set; }
        public string value { get; set; }
    }
}
