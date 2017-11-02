using System.Runtime.Serialization;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraAccount
    {
        public void Initialize(JiraUser jiraUser)
        {
            this.Name = jiraUser.name;
            this.EmailAddress = jiraUser.emailAddress;
            this.DisplayName = jiraUser.displayName;
            this.IsActive = jiraUser.active;
        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
