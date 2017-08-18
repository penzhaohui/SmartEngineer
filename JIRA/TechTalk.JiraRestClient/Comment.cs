using System;

namespace TechTalk.JiraRestClient
{
    public class Comment
    {
        public string id { get; set; }
        public string body { get; set; }
        public JiraUser Author { get; set; }
        public JiraUser UpdateAuthor { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
