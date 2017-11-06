using System.Runtime.Serialization;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class Member : BasicDataModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public int TenantID { get; set; }
        [DataMember]
        public string TenantName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Signature { get; set; }        
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string EmailPassword { get; set; }
        [DataMember]
        public string JiraAccountID { get; set; }
        [DataMember]
        public string JiraAccount { get; set; }
        [DataMember]
        public string JiraPassword { get; set; }
        [DataMember]
        public string TestRailAccountID { get; set; }
        [DataMember]
        public string TestRailAccount { get; set; }
        [DataMember]
        public string TestRailPassword { get; set; }
        [DataMember]
        public string GitHubAccountID { get; set; }
        [DataMember]
        public string GitHubAccount { get; set; }
        [DataMember]
        public string GitHubPassword { get; set; }
    }
}
