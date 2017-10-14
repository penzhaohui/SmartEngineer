using Newtonsoft.Json;
using Salesforce.Common.Models;
using System;

namespace SmartEngineer.Core.Models
{
    // Salesforce inspector - Chrome and Firefox extension to add a metadata layout on top of the standard Salesforce UI to improve the productivity and joy of Salesforce configuration, development, and integration work.
    // https://github.com/sorenkrabbe/Chrome-Salesforce-inspector
    public class AccelaCase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "CaseNumber")]
        public string CaseNumber { get; set; }

        #region Case Detail

        // Created By
        [JsonProperty(PropertyName = "CreatedBy")]
        public Account CreatedBy { get; set; }

        // Case Record Type
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType CaseType { get; set; }

        // Date/Time Opened
        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        // Case Owner
        [JsonProperty(PropertyName = "Owner")]
        public Account Owner { get; set; }

        // Last Comment Added
        // Last_Comment_By__c

        // Case Origin
        [JsonProperty(PropertyName = "Origin")]
        public string Origin { get; set; }

        // Current on Maintenance
        // Current on Maintenance

        // Last Modified By
        // Last Modified By

        // Jira Issue URL
        // Jira_Issue_URL__c

        #endregion

        #region Primary Contact

        // Account Name
        [JsonProperty(PropertyName = "Account")]
        public Account Account { get; set; }

        // Contact Name

        // Customer
        [JsonProperty(PropertyName = "Customer__r")]
        public Account Customer { get; set; }

        // Contact Email

        // Hosted
        [JsonProperty(PropertyName = "hosted__c")]
        public string Hosted { get; set; }

        // Contact Phone

        // Sensitive Client
        // Sensitive Client

        #endregion


        #region Case Information

        // Priority
        [JsonProperty(PropertyName = "Priority")]
        public string Priority { get; set; }

        // Type     
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        // Status
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        // Parent Case

        // Product
        [JsonProperty(PropertyName = "Product__c")]
        public string Product { get; set; }

        // Release Info
        [JsonProperty(PropertyName = "release_info__c")]
        public string ReleaseInfo { get; set; }

        // Solution
        [JsonProperty(PropertyName = "solution__c")]
        public string Solution { get; set; }

        // Scheduled Release
        // Scheduled Release

        // Current Version
        [JsonProperty(PropertyName = "Current_Version__c")]
        public string CurrentVersion { get; set; }

        // Targeted Release
        [JsonProperty(PropertyName = "targeted_release__c")]
        public string TargetedRelease { get; set; }

        // Patch Number
        [JsonProperty(PropertyName = "Patch_Number__c")]
        public string PatchNumber { get; set; }

        // Blocked
        // Blocked__c

        // Escalated By
        // Escalated_By__c

        #endregion

        #region Description Information

        // Subject
        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; set; }

        // Description
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        #endregion

        #region Engineering

        // Internal Type
        [JsonProperty(PropertyName = "Internal_Type__c")]
        public string InternalType { get; set; }

        // Engineering Status
        [JsonProperty(PropertyName = "Engineering_Status__c")]
        public string EngineeringStatus { get; set; }

        // Engineering Assignment
        // Engineering_Assignment__c

        // Engineering Comment
        // Engineering_Comment__c

        // Internal Severity
        // Internal_Severity__c        

        // BZID
        [JsonProperty(PropertyName = "BZID__c")]
        public string BZID { get; set; }

        // Issue Category
        // Issue_Category__c

        // Dev LOEE Confidence
        // Dev_LOEE_Confidence__c

        // Release Note Content
        // Release_Note_Content__c

        #endregion

        #region Product Management

        // Rank Order
        [JsonProperty(PropertyName = "Rank_Order__c")]
        public string RankOrder { get; set; }

        #endregion

        #region Services

        // Go-Live Critical
        [JsonProperty(PropertyName = "Go_Live_Critical__c")]
        public string GoLiveCritical { get; set; }

        // Services Rank
        [JsonProperty(PropertyName = "Services_Rank__c")]
        public string ServicesRank { get; set; }      

        #endregion

        [JsonProperty(PropertyName = "CaseComments")]
        public QueryResult<CaseComment> CaseComments { get; set; }

        [JsonProperty(PropertyName = "Attachments")]
        public QueryResult<CaseAttachment> CaseAttachments { get; set; }
    }
}
