using System.Runtime.Serialization;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraSubTask : BasicDataModel
    {
        public void Initialize(SubTask subTask)
        {
            this.JiraID = subTask.id;
            this.JiraKey = subTask.key;
            this.ProjectKey = subTask.fields.project.key;
            this.Type = subTask.fields.IssueType.name;
            this.Summary = subTask.fields.Summary;
            this.Description = subTask.fields.Description;
            this.Assignee = subTask.fields.Assignee.name;
            //this.AssigneeQA = subTask.fields.AssigneeQA.name;
            this.TotalTimeSpentHours = subTask.fields.Timespent/3600;
            this.Status = subTask.fields.Status.name;
            this.ParentJiraKey = subTask.fields.Parent.key;

        }

        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string JiraID { get; set; }
        [DataMember]
        public string JiraKey { get; set; }
        [DataMember]
        public string ProjectKey { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Assignee { get; set; }
        [DataMember]
        public string AssigneeQA { get; set; }
        [DataMember]
        public int TotalTimeSpentHours { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string ParentJiraKey { get; set; }
    }
}
