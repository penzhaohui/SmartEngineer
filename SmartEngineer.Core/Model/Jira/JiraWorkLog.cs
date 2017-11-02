using System;
using System.Runtime.Serialization;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraWorkLog : BasicDataModel
    {
        public void Initialize(string jiraKey, Worklog worklog)
        {
            this.WorklogID = worklog.id;
            this.CommentBody = worklog.comment;
            this.CreatedByID = worklog.author.id;
            this.CreatedByName = worklog.author.name;
            this.CreatedDateTime = worklog.created;
            this.LastModifiedByID = worklog.updateAuthor.id;
            this.LastModifiedByName = worklog.updateAuthor.name;
            this.LastModifiedDateTime = worklog.updated;
            this.TimeSpentHours = worklog.timeSpentSeconds/3600;
            this.TimeSpendSeconds = worklog.timeSpentSeconds;
            this.ParentJiraKey = jiraKey;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string WorklogID { get; set; }
        [DataMember]
        public string CommentBody { get; set; }
        [DataMember]
        public string CreatedByID { get; set; }
        [DataMember]
        public string CreatedByName { get; set; }
        [DataMember]
        public DateTime CreatedDateTime { get; set; }
        [DataMember]
        public string LastModifiedByID { get; set; }
        [DataMember]
        public string LastModifiedByName { get; set; }
        [DataMember]
        public DateTime LastModifiedDateTime { get; set; }
        [DataMember]
        public double TimeSpentHours { get; set; }
        [DataMember]
        public double TimeSpendSeconds { get; set; }
        [DataMember]
        public string ParentJiraKey { get; set; }
    }
}
