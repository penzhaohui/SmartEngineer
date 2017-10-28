using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient
{
    public class IssueFields
    {
        public IssueFields()
        {
            Status = new Status();
            TimeTracking = new Timetracking();

            Labels = new List<String>();
            comments = new List<Comment>();
            issuelinks = new List<IssueLink>();
            attachment = new List<Attachment>();
            watchers = new List<JiraUser>();

            Product = new List<IssueProduct>();
            IssueCategory = new List<IssueCategory>();
            BuildVersion = new List<string>();
        }

        #region Jira Basic Information

        /// <summary>
        /// Jira Issue Subject
        /// </summary>
        public String Summary { get; set; }
        /// <summary>
        /// Jira Issue Type
        /// </summary>
        public IssueType IssueType { get; set; }
        /// <summary>
        /// Jira Status
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Low - https://accelaeng.atlassian.net/rest/api/2/priority/8
        /// High - https://accelaeng.atlassian.net/rest/api/2/priority/7
        /// Medium - https://accelaeng.atlassian.net/rest/api/2/priority/6
        /// Trivial - https://accelaeng.atlassian.net/rest/api/2/priority/5
        /// Minor - https://accelaeng.atlassian.net/rest/api/2/priority/4
        /// Major - https://accelaeng.atlassian.net/rest/api/2/priority/3
        /// Critical - https://accelaeng.atlassian.net/rest/api/2/priority/2
        /// Blocker - https://accelaeng.atlassian.net/rest/api/2/priority/1
        /// </summary>
        public IssuePriority Priority { get; set; }
        /// <summary>
        /// Jira Labels
        /// </summary>
        public List<String> Labels { get; set; }        
        /// <summary>
        /// Case Description
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Fix Versions
        /// </summary>
        public List<IssueFixVersion> FixVersions { get; set; }

        /// <summary>
        /// Reporter
        /// </summary>
        public JiraUser Reporter { get; set; }

        /// <summary>
        /// Assignee
        /// </summary>
        public JiraUser Assignee { get; set; }

        /// <summary>
        /// Assigned QA
        /// </summary>
        [DeserializeAs(Name = "customfield_11702")]
        public JiraUser AssignedQA { get; set; }

        #endregion

        #region Jira Table Information

        /// <summary>
        /// Case Number
        /// </summary>
        [DeserializeAs(Name = "customfield_10600")]
        public String CaseNumber { get; set; }

        /// <summary>
        /// Build Version
        /// </summary>
        [DeserializeAs(Name = "customfield_10907")]
        public List<String> BuildVersion { get; set; }

        /// <summary>
        /// Severity
        /// 
        /// Critical - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10413
        /// Major - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10414
        /// Medium - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10415
        /// Low - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10416
        /// </summary>
        public IssueSeverity Severity { get; set; }
        
        /// <summary>
        /// JIRA-Product
        /// 
        /// Accela ACA - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10800
        /// Accela ACA Mobile - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10801
        /// Accela ARW - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10802
        /// Accela Asset Management - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10803
        /// Accela Automation - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10804
        /// Accela EDR - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10805
        /// Accela GIS - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10806
        /// Accela IVR - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10807
        /// Accela Licensing & Case Management - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10808
        /// Accela Mobile - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10809
        /// Accela Public Health & Safety - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10810
        /// Accela Wireless - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10811
        /// Civic Hero - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10812
        /// Code Officer - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10813
        /// Kiva - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10814
        /// Mobile Gateway - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10815
        /// Mobile Office -  https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10816
        /// Permits Plus - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10817
        /// Tidemark - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10818
        /// Accela Ad Hoc - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11400
        /// 
        /// </summary>
        [DeserializeAs(Name = "customfield_11501")]
        public List<IssueProduct> Product { get; set; }

        /// <summary>
        /// Issue Category
        /// </summary>
        [DeserializeAs(Name = "customfield_11502")]
        public List<IssueCategory> IssueCategory { get; set; }

        /// <summary>
        /// Estimated Effort
        /// </summary>
        [DeserializeAs(Name = "customfield_11506")]
        public int EstimatedEffort { get; set; }

        /// <summary>
        /// SF Comment Count
        /// </summary>
        [DeserializeAs(Name = "customfield_12400")]
        public int SFCommentCount { get; set; }

        /// <summary>
        /// SF-Priority
        /// </summary>
        [DeserializeAs(Name = "customfield_12801")]
        public string SFPriority { get; set; }

        /// <summary>
        /// SF-Customer
        /// </summary>
        [DeserializeAs(Name = "customfield_10900")]
        public String SFCustomer { get; set; }

        #endregion

        #region Salesforce Table Information
        /// <summary>
        /// SF-Current Version
        /// </summary>
        [DeserializeAs(Name = "customfield_10901")]
        public String SFCurrentVersion { get; set; }

        /// <summary>
        /// SF-Product
        /// </summary>
        [DeserializeAs(Name = "customfield_10904")]
        public String SFProduct { get; set; }

        /// <summary>
        /// SF-Salesforce Link
        /// </summary>
        [DeserializeAs(Name = "customfield_10906")]
        public String SFSalesforceLink { get; set; }

        /// <summary>
        /// SF-Date/Time Opened
        /// </summary>
        [DeserializeAs(Name = "customfield_10902")]
        public DateTime SFOpenedDateTime { get; set; }

        /// <summary>
        /// SF-Last Modified
        /// </summary>
        [DeserializeAs(Name = "customfield_10903")]
        public DateTime SFLastModifiedDate { get; set; }

        /// <summary>
        /// SF-Origin
        /// 
        /// Bugzilla - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11401
        /// Phone - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11402
        /// Email - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11403
        /// Engineering - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11404
        /// Other - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11405
        /// Partner - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11406
        /// Product Management - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11407
        /// Sales - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11408
        /// Services - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11409
        /// Web - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11410
        /// Chatter Answers - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11411
        /// Customer Support - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11412
        /// Success Community - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/11413
        /// </summary>
        [DeserializeAs(Name = "customfield_11900")]
        public IssueOrigin SFOrigin { get; set; }

        /// <summary>
        /// SF-Targeted Release
        /// </summary>
        [DeserializeAs(Name = "customfield_12300")]
        public String SFTargetedRelease { get; set; }

        #endregion

        public Timetracking TimeTracking { get; set; }
        
        public DateTime Updated { get; set; }
        
        public List<JiraUser> watchers { get; set; }

        public List<Comment> comments { get; set; }
        public List<IssueLink> issuelinks { get; set; }
        public List<Attachment> attachment { get; set; }
        
    }
}