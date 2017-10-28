using System;
using System.Runtime.Serialization;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraIssueComment
    {
        public void Initialize(string jiraKey, Comment comment)
        {
            this.CreatedByID = comment.Author.id;
            this.CommentBody = comment.body;
            this.CreatedByName = comment.Author.name;
            this.CreatedDateTime = comment.Created;
            this.LastModifiedByID = comment.UpdateAuthor.id;
            this.LastModifiedByName = comment.UpdateAuthor.name;
            this.LastModifiedDateTime = comment.Updated;
            this.JiraCommentID = comment.id;
            this.ParentJiraKey = jiraKey;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CreatedByID { get; set; }
        [DataMember]
        public string CommentBody { get; set; }
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
        public string ParentJiraKey { get; set; }
        [DataMember]
        public string JiraCommentID { get; set; }
        [DataMember]
        public string SFCommentID { get; set; }
    }
}
