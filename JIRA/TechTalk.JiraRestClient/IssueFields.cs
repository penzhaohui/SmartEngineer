using System;
using System.Collections.Generic;

namespace TechTalk.JiraRestClient
{
    public class IssueFields
    {
        public IssueFields()
        {
            status = new Status();
            timetracking = new Timetracking();

            labels = new List<String>();
            comments = new List<Comment>();
            issuelinks = new List<IssueLink>();
            attachment = new List<Attachment>();
            watchers = new List<JiraUser>();

            customfield_11502 = new List<IssueCategory>(); 
            customfield_10907 = new List<string>();
        }

        /// <summary>
        /// Issue Type
        /// </summary>
        public IssueType issueType { get; set; }

        /// <summary>
        /// Case Subject
        /// </summary>
        public String summary { get; set; }
        /// <summary>
        /// Case Description
        /// </summary>
        public String description { get; set; }
        /// <summary>
        /// Case Number
        /// </summary>
        public String customfield_10600 { get; set; }
        /// <summary>
        /// Build Version
        /// </summary>
        public List<String> customfield_10907 { get; set; }
        public String customfield_10021 { get; set; }
        public String customfield_10001 { get; set; }
        
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
        public String customfield_11501 { get; set; }
        /// <summary>
        /// Issue Category
        /// </summary>
        public List<IssueCategory> customfield_11502 { get; set; }
        /// <summary>
        /// SF-Customer
        /// </summary>
        public String customfield_10900 { get; set; }
        /// <summary>
        /// SF-Current Version
        /// </summary>
        public String customfield_10901 { get; set; }
        /// <summary>
        /// SF-Open
        /// </summary>
        public String customfield_10902 { get; set; }
        /// <summary>
        /// SF-Last Modified
        /// </summary>
        public String customfield_10903 { get; set; }
        /// <summary>
        /// SF-Product
        /// </summary>
        public String customfield_10904 { get; set; }
        /// <summary>
        /// SF-Reopen Count
        /// </summary>
        public int customfield_12400 { get; set; }
        /// <summary>
        /// SF-Targeted Release
        /// </summary>
        public String customfield_12300 { get; set; }

        /// <summary>
        /// Estimated Effort
        /// </summary>
        public int customfield_11506 { get; set; }

        /// <summary>
        /// Sub Tasks
        /// </summary>
        public List<SubTask> subtasks { get; set; } 
 
        /// <summary>
        /// Parent Tasks
        /// </summary>
        public SubTask parent { get; set; }     

        /// <summary>
        /// SF-Priority
        /// 
        /// Critical - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10200
        /// High - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10201
        /// Medium - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10202
        /// Low - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10203
        /// </summary>
        public String customfield_10905 { get; set; }
        /// <summary>
        /// SF-Salesforce Link
        /// </summary>
        public String customfield_10906 { get; set; }
        /// <summary>
        /// Severity
        /// 
        /// Critical - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10413
        /// Major - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10414
        /// Medium - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10415
        /// Low - https://accelaeng.atlassian.net/rest/api/2/customFieldOption/10416
        /// </summary>
        public IssueSeverity customfield_11106 { get; set; }

        /// <summary>
        /// SF-Priority
        /// </summary>
        public string customfield_12801 { get; set; }

        /// <summary>
        /// Assigned QA
        /// </summary>
        public JiraUser customfield_11702 { get; set; }

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
        public String customfield_11900 { get; set; }

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

        public Timetracking timetracking { get; set; }
        public Status status { get; set; }
        public DateTime updated { get; set; }

        public JiraUser reporter { get; set; }
        public JiraUser assignee { get; set; }
        public List<JiraUser> watchers { get; set; }

        public List<String> labels { get; set; }
        public List<Comment> comments { get; set; }
        public List<IssueLink> issuelinks { get; set; }
        public List<Attachment> attachment { get; set; }
        public List<IssueFixVersion> fixVersions { get; set; }
    }
}