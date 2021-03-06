﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    [DataContract]
    public class JiraIssue : BasicDataModel
    {
        public void Initialize(Issue jiraIssue)
        {
            this.JiraID = jiraIssue.id;
            this.JiraKey = jiraIssue.key;
            this.ProjectKey = jiraIssue.fields.Project.key;
            this.IssueType = jiraIssue.fields.IssueType.name;
            this.Summary = jiraIssue.fields.Summary;
            this.Status = jiraIssue.fields.Status.name;
            this.Priority = jiraIssue.fields.Priority.name;
            this.Labels = String.Join(",", jiraIssue.fields.Labels);
            this.Description = jiraIssue.fields.Description;
            this.FixVersions = String.Join(",", jiraIssue.fields.FixVersions.Select(version => version.name).ToArray());
            this.Reporter = jiraIssue.fields.Reporter.name;
            this.Assignee = jiraIssue.fields.Assignee.name;
            this.AssignedQA = (jiraIssue.fields.AssignedQA == null ? null : jiraIssue.fields.AssignedQA.name);
            this.CaseNumber = jiraIssue.fields.CaseNumber;
            this.BuildVersion = (jiraIssue.fields.BuildVersion != null && jiraIssue.fields.BuildVersion.Count > 0 ? jiraIssue.fields.BuildVersion[0] : null);
            this.Severity = (jiraIssue.fields.Severity == null ? null : jiraIssue.fields.Severity.name);
            this.Product = (jiraIssue.fields.Product != null && jiraIssue.fields.Product.Count > 0 ? jiraIssue.fields.Product[0].value : null);
            this.IssueCategory = (jiraIssue.fields.IssueCategory != null && jiraIssue.fields.IssueCategory.Count > 0 ? jiraIssue.fields.IssueCategory[0].value : null);
            this.EstimatedEffort = jiraIssue.fields.EstimatedEffort;
            this.SFCommentCount = jiraIssue.fields.SFCommentCount;
            this.SFPriority = jiraIssue.fields.SFPriority;
            this.SFCustomer = jiraIssue.fields.SFCustomer;
            this.SFCurrentVersion = jiraIssue.fields.SFCurrentVersion;
            this.SFProduct = jiraIssue.fields.SFProduct;
            this.SFSalesforceLink = jiraIssue.fields.SFSalesforceLink;
            this.SFOpenedDateTime = null;
            this.SFOpenedDateTime = jiraIssue.fields.SFOpenedDateTime;
            if (this.SFOpenedDateTime == DateTime.MinValue)
            {
                this.SFOpenedDateTime = null;
            }

            this.SFLastModifiedDate = jiraIssue.fields.SFLastModifiedDate;
            if (this.SFLastModifiedDate == DateTime.MinValue)
            {
                this.SFLastModifiedDate = null;
            }
            this.SFOrigin = (jiraIssue.fields.SFOrigin == null ? null : jiraIssue.fields.SFOrigin.value);
            this.SFTargetedRelease = jiraIssue.fields.SFTargetedRelease;

            this.CreatedDate = jiraIssue.fields.UpdatedDate;
            if (this.CreatedDate == DateTime.MinValue)
            {
                this.CreatedDate = null;
            }
            this.UpdatedDate = jiraIssue.fields.UpdatedDate;
            if (this.UpdatedDate == DateTime.MinValue)
            {
                this.UpdatedDate = null;
            }
            this.Resolutiondate = jiraIssue.fields.UpdatedDate;
            if (this.Resolutiondate == DateTime.MinValue)
            {
                this.Resolutiondate = null;
            }

            this.TimeSpent = jiraIssue.fields.TimeSpent;
            this.TimeEstimate = jiraIssue.fields.TimeEstimate;
            this.AggregateTimeSpent = jiraIssue.fields.AggregateTimeSpent;
            this.AggregateTimeOriginalEstimate = jiraIssue.fields.AggregateTimeOriginalEstimate;
            this.Environment = jiraIssue.fields.Environment;
            this.Components = jiraIssue.fields.Component?.value;
            if (jiraIssue.fields.comments != null)
            {
                this.Components += string.Join(",", this.Components);
            }

            this.SelfRating = jiraIssue.fields.SelfRating?.value;
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
        public string IssueType { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public string Labels { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string FixVersions { get; set; }
        [DataMember]
        public string Reporter { get; set; }
        [DataMember]
        public string Assignee { get; set; }
        [DataMember]
        public string AssignedQA { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string BuildVersion { get; set; }
        [DataMember]
        public string Severity { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string IssueCategory { get; set; }
        [DataMember]
        public int EstimatedEffort { get; set; }
        [DataMember]
        public int SFCommentCount { get; set; }
        [DataMember]
        public string SFPriority { get; set; }
        [DataMember]
        public string SFCustomer { get; set; }
        [DataMember]
        public string SFCurrentVersion { get; set; }
        [DataMember]
        public string SFProduct { get; set; }
        [DataMember]
        public string SFSalesforceLink { get; set; }
        [DataMember]
        public DateTime? SFOpenedDateTime { get; set; }
        [DataMember]
        public DateTime? SFLastModifiedDate { get; set; }
        [DataMember]
        public string SFOrigin { get; set; }
        [DataMember]
        public string SFTargetedRelease { get; set; }

        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public DateTime? Resolutiondate { get; set; }

        [DataMember]
        public int TimeSpent { get; set; }
        [DataMember]
        public int TimeEstimate { get; set; }
        [DataMember]
        public int AggregateTimeSpent { get; set; }
        [DataMember]
        public string AggregateTimeOriginalEstimate { get; set; }
        [DataMember]
        public string Environment { get; set; }
        [DataMember]
        public string Components { get; set; }
        [DataMember]
        public string SelfRating { get; set; }
    }
}
