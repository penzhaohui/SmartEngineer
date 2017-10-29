using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient
{
    internal class SubTaskContainer
    {
        public string expand { get; set; }

        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }

        [DeserializeAs(Name = "issues")]
        public List<SubTask> subTasks { get; set; }
    }
}
