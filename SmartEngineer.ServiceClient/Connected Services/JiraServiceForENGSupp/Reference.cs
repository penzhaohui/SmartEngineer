﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartEngineer.ServiceClient.JiraServiceForENGSupp {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JiraIssue", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    public partial class JiraIssue : SmartEngineer.ServiceClient.JiraServiceForENGSupp.BasicDataModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AggregateTimeOriginalEstimateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AggregateTimeSpentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AssignedQAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AssigneeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaseNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ComponentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreatedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EnvironmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EstimatedEffortField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FixVersionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IssueCategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IssueTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JiraIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string JiraKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LabelsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReporterField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ResolutiondateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SFCommentCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFCurrentVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFCustomerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SFLastModifiedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> SFOpenedDateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFOriginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFPriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFSalesforceLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SFTargetedReleaseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SelfRatingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SeverityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SummaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TimeEstimateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TimeSpentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> UpdatedDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AggregateTimeOriginalEstimate {
            get {
                return this.AggregateTimeOriginalEstimateField;
            }
            set {
                if ((object.ReferenceEquals(this.AggregateTimeOriginalEstimateField, value) != true)) {
                    this.AggregateTimeOriginalEstimateField = value;
                    this.RaisePropertyChanged("AggregateTimeOriginalEstimate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AggregateTimeSpent {
            get {
                return this.AggregateTimeSpentField;
            }
            set {
                if ((this.AggregateTimeSpentField.Equals(value) != true)) {
                    this.AggregateTimeSpentField = value;
                    this.RaisePropertyChanged("AggregateTimeSpent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AssignedQA {
            get {
                return this.AssignedQAField;
            }
            set {
                if ((object.ReferenceEquals(this.AssignedQAField, value) != true)) {
                    this.AssignedQAField = value;
                    this.RaisePropertyChanged("AssignedQA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Assignee {
            get {
                return this.AssigneeField;
            }
            set {
                if ((object.ReferenceEquals(this.AssigneeField, value) != true)) {
                    this.AssigneeField = value;
                    this.RaisePropertyChanged("Assignee");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BuildVersion {
            get {
                return this.BuildVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildVersionField, value) != true)) {
                    this.BuildVersionField = value;
                    this.RaisePropertyChanged("BuildVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CaseNumber {
            get {
                return this.CaseNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.CaseNumberField, value) != true)) {
                    this.CaseNumberField = value;
                    this.RaisePropertyChanged("CaseNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Components {
            get {
                return this.ComponentsField;
            }
            set {
                if ((object.ReferenceEquals(this.ComponentsField, value) != true)) {
                    this.ComponentsField = value;
                    this.RaisePropertyChanged("Components");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CreatedDate {
            get {
                return this.CreatedDateField;
            }
            set {
                if ((this.CreatedDateField.Equals(value) != true)) {
                    this.CreatedDateField = value;
                    this.RaisePropertyChanged("CreatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Environment {
            get {
                return this.EnvironmentField;
            }
            set {
                if ((object.ReferenceEquals(this.EnvironmentField, value) != true)) {
                    this.EnvironmentField = value;
                    this.RaisePropertyChanged("Environment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EstimatedEffort {
            get {
                return this.EstimatedEffortField;
            }
            set {
                if ((this.EstimatedEffortField.Equals(value) != true)) {
                    this.EstimatedEffortField = value;
                    this.RaisePropertyChanged("EstimatedEffort");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FixVersions {
            get {
                return this.FixVersionsField;
            }
            set {
                if ((object.ReferenceEquals(this.FixVersionsField, value) != true)) {
                    this.FixVersionsField = value;
                    this.RaisePropertyChanged("FixVersions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssueCategory {
            get {
                return this.IssueCategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.IssueCategoryField, value) != true)) {
                    this.IssueCategoryField = value;
                    this.RaisePropertyChanged("IssueCategory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IssueType {
            get {
                return this.IssueTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.IssueTypeField, value) != true)) {
                    this.IssueTypeField = value;
                    this.RaisePropertyChanged("IssueType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string JiraID {
            get {
                return this.JiraIDField;
            }
            set {
                if ((object.ReferenceEquals(this.JiraIDField, value) != true)) {
                    this.JiraIDField = value;
                    this.RaisePropertyChanged("JiraID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string JiraKey {
            get {
                return this.JiraKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.JiraKeyField, value) != true)) {
                    this.JiraKeyField = value;
                    this.RaisePropertyChanged("JiraKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Labels {
            get {
                return this.LabelsField;
            }
            set {
                if ((object.ReferenceEquals(this.LabelsField, value) != true)) {
                    this.LabelsField = value;
                    this.RaisePropertyChanged("Labels");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((object.ReferenceEquals(this.PriorityField, value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProjectKey {
            get {
                return this.ProjectKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectKeyField, value) != true)) {
                    this.ProjectKeyField = value;
                    this.RaisePropertyChanged("ProjectKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reporter {
            get {
                return this.ReporterField;
            }
            set {
                if ((object.ReferenceEquals(this.ReporterField, value) != true)) {
                    this.ReporterField = value;
                    this.RaisePropertyChanged("Reporter");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Resolutiondate {
            get {
                return this.ResolutiondateField;
            }
            set {
                if ((this.ResolutiondateField.Equals(value) != true)) {
                    this.ResolutiondateField = value;
                    this.RaisePropertyChanged("Resolutiondate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SFCommentCount {
            get {
                return this.SFCommentCountField;
            }
            set {
                if ((this.SFCommentCountField.Equals(value) != true)) {
                    this.SFCommentCountField = value;
                    this.RaisePropertyChanged("SFCommentCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFCurrentVersion {
            get {
                return this.SFCurrentVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.SFCurrentVersionField, value) != true)) {
                    this.SFCurrentVersionField = value;
                    this.RaisePropertyChanged("SFCurrentVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFCustomer {
            get {
                return this.SFCustomerField;
            }
            set {
                if ((object.ReferenceEquals(this.SFCustomerField, value) != true)) {
                    this.SFCustomerField = value;
                    this.RaisePropertyChanged("SFCustomer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> SFLastModifiedDate {
            get {
                return this.SFLastModifiedDateField;
            }
            set {
                if ((this.SFLastModifiedDateField.Equals(value) != true)) {
                    this.SFLastModifiedDateField = value;
                    this.RaisePropertyChanged("SFLastModifiedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> SFOpenedDateTime {
            get {
                return this.SFOpenedDateTimeField;
            }
            set {
                if ((this.SFOpenedDateTimeField.Equals(value) != true)) {
                    this.SFOpenedDateTimeField = value;
                    this.RaisePropertyChanged("SFOpenedDateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFOrigin {
            get {
                return this.SFOriginField;
            }
            set {
                if ((object.ReferenceEquals(this.SFOriginField, value) != true)) {
                    this.SFOriginField = value;
                    this.RaisePropertyChanged("SFOrigin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFPriority {
            get {
                return this.SFPriorityField;
            }
            set {
                if ((object.ReferenceEquals(this.SFPriorityField, value) != true)) {
                    this.SFPriorityField = value;
                    this.RaisePropertyChanged("SFPriority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFProduct {
            get {
                return this.SFProductField;
            }
            set {
                if ((object.ReferenceEquals(this.SFProductField, value) != true)) {
                    this.SFProductField = value;
                    this.RaisePropertyChanged("SFProduct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFSalesforceLink {
            get {
                return this.SFSalesforceLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.SFSalesforceLinkField, value) != true)) {
                    this.SFSalesforceLinkField = value;
                    this.RaisePropertyChanged("SFSalesforceLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SFTargetedRelease {
            get {
                return this.SFTargetedReleaseField;
            }
            set {
                if ((object.ReferenceEquals(this.SFTargetedReleaseField, value) != true)) {
                    this.SFTargetedReleaseField = value;
                    this.RaisePropertyChanged("SFTargetedRelease");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SelfRating {
            get {
                return this.SelfRatingField;
            }
            set {
                if ((object.ReferenceEquals(this.SelfRatingField, value) != true)) {
                    this.SelfRatingField = value;
                    this.RaisePropertyChanged("SelfRating");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Severity {
            get {
                return this.SeverityField;
            }
            set {
                if ((object.ReferenceEquals(this.SeverityField, value) != true)) {
                    this.SeverityField = value;
                    this.RaisePropertyChanged("Severity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Summary {
            get {
                return this.SummaryField;
            }
            set {
                if ((object.ReferenceEquals(this.SummaryField, value) != true)) {
                    this.SummaryField = value;
                    this.RaisePropertyChanged("Summary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TimeEstimate {
            get {
                return this.TimeEstimateField;
            }
            set {
                if ((this.TimeEstimateField.Equals(value) != true)) {
                    this.TimeEstimateField = value;
                    this.RaisePropertyChanged("TimeEstimate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TimeSpent {
            get {
                return this.TimeSpentField;
            }
            set {
                if ((this.TimeSpentField.Equals(value) != true)) {
                    this.TimeSpentField = value;
                    this.RaisePropertyChanged("TimeSpent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> UpdatedDate {
            get {
                return this.UpdatedDateField;
            }
            set {
                if ((this.UpdatedDateField.Equals(value) != true)) {
                    this.UpdatedDateField = value;
                    this.RaisePropertyChanged("UpdatedDate");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasicDataModel", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue))]
    public partial class BasicDataModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JiraServiceForENGSupp.IJiraServiceForENGSupp")]
    public interface IJiraServiceForENGSupp {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabels", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabelsResponse")]
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByLabels(string[] labels);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabels", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabelsResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByLabelsAsync(string[] labels);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetPendingCaseList", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetPendingCaseListResponse")]
        string[] GetPendingCaseList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetPendingCaseList", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetPendingCaseListResponse")]
        System.Threading.Tasks.Task<string[]> GetPendingCaseListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatuses", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatusesResponse")]
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByStatuses(string[] statuses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatuses", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatusesResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByStatusesAsync(string[] statuses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNos", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNosResponse")]
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByCaseNos(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNos", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNosResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByCaseNosAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseNOs", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseNOsResponse")]
        bool ImportCaseNOs(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseNOs", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseNOsResponse")]
        System.Threading.Tasks.Task<bool> ImportCaseNOsAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseComments", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseCommentsResponse")]
        bool ImportCaseComments(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseComments", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/ImportCaseCommentsResponse")]
        System.Threading.Tasks.Task<bool> ImportCaseCommentsAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/SyncIssueStatus", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/SyncIssueStatusResponse")]
        bool SyncIssueStatus(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/SyncIssueStatus", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/SyncIssueStatusResponse")]
        System.Threading.Tasks.Task<bool> SyncIssueStatusAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/SyncSalesforceCaseToJiraIssue", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/SyncSalesforceCaseToJiraIssueResponse")]
        bool SyncSalesforceCaseToJiraIssue(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/SyncSalesforceCaseToJiraIssue", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/SyncSalesforceCaseToJiraIssueResponse")]
        System.Threading.Tasks.Task<bool> SyncSalesforceCaseToJiraIssueAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssues", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssuesResponse")]
        string[] GetNewIssues(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssues", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssuesResponse")]
        System.Threading.Tasks.Task<string[]> GetNewIssuesAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssues", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssuesResponse")]
        string[] GetResolvedIssues(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssues", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssuesResponse")]
        System.Threading.Tasks.Task<string[]> GetResolvedIssuesAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugs", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugsResponse")]
        string[] GetProductionBugs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugs", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugsResponse")]
        System.Threading.Tasks.Task<string[]> GetProductionBugsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetTotalTimeSpent", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetTotalTimeSpentResponse")]
        int GetTotalTimeSpent(string subTaskKey, System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetTotalTimeSpent", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetTotalTimeSpentResponse")]
        System.Threading.Tasks.Task<int> GetTotalTimeSpentAsync(string subTaskKey, System.DateTime from, System.DateTime to);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJiraServiceForENGSuppChannel : SmartEngineer.ServiceClient.JiraServiceForENGSupp.IJiraServiceForENGSupp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JiraServiceForENGSuppClient : System.ServiceModel.ClientBase<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IJiraServiceForENGSupp>, SmartEngineer.ServiceClient.JiraServiceForENGSupp.IJiraServiceForENGSupp {
        
        public JiraServiceForENGSuppClient() {
        }
        
        public JiraServiceForENGSuppClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public JiraServiceForENGSuppClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JiraServiceForENGSuppClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JiraServiceForENGSuppClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByLabels(string[] labels) {
            return base.Channel.GetIssuesByLabels(labels);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByLabelsAsync(string[] labels) {
            return base.Channel.GetIssuesByLabelsAsync(labels);
        }
        
        public string[] GetPendingCaseList() {
            return base.Channel.GetPendingCaseList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetPendingCaseListAsync() {
            return base.Channel.GetPendingCaseListAsync();
        }
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByStatuses(string[] statuses) {
            return base.Channel.GetIssuesByStatuses(statuses);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByStatusesAsync(string[] statuses) {
            return base.Channel.GetIssuesByStatusesAsync(statuses);
        }
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[] GetIssuesByCaseNos(string[] caseNOs) {
            return base.Channel.GetIssuesByCaseNos(caseNOs);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.JiraIssue[]> GetIssuesByCaseNosAsync(string[] caseNOs) {
            return base.Channel.GetIssuesByCaseNosAsync(caseNOs);
        }
        
        public bool ImportCaseNOs(string[] caseNOs) {
            return base.Channel.ImportCaseNOs(caseNOs);
        }
        
        public System.Threading.Tasks.Task<bool> ImportCaseNOsAsync(string[] caseNOs) {
            return base.Channel.ImportCaseNOsAsync(caseNOs);
        }
        
        public bool ImportCaseComments(string[] caseNOs) {
            return base.Channel.ImportCaseComments(caseNOs);
        }
        
        public System.Threading.Tasks.Task<bool> ImportCaseCommentsAsync(string[] caseNOs) {
            return base.Channel.ImportCaseCommentsAsync(caseNOs);
        }
        
        public bool SyncIssueStatus(string[] caseNOs) {
            return base.Channel.SyncIssueStatus(caseNOs);
        }
        
        public System.Threading.Tasks.Task<bool> SyncIssueStatusAsync(string[] caseNOs) {
            return base.Channel.SyncIssueStatusAsync(caseNOs);
        }
        
        public bool SyncSalesforceCaseToJiraIssue(string[] caseNOs) {
            return base.Channel.SyncSalesforceCaseToJiraIssue(caseNOs);
        }
        
        public System.Threading.Tasks.Task<bool> SyncSalesforceCaseToJiraIssueAsync(string[] caseNOs) {
            return base.Channel.SyncSalesforceCaseToJiraIssueAsync(caseNOs);
        }
        
        public string[] GetNewIssues(System.DateTime from, System.DateTime to) {
            return base.Channel.GetNewIssues(from, to);
        }
        
        public System.Threading.Tasks.Task<string[]> GetNewIssuesAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetNewIssuesAsync(from, to);
        }
        
        public string[] GetResolvedIssues(System.DateTime from, System.DateTime to) {
            return base.Channel.GetResolvedIssues(from, to);
        }
        
        public System.Threading.Tasks.Task<string[]> GetResolvedIssuesAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetResolvedIssuesAsync(from, to);
        }
        
        public string[] GetProductionBugs() {
            return base.Channel.GetProductionBugs();
        }
        
        public System.Threading.Tasks.Task<string[]> GetProductionBugsAsync() {
            return base.Channel.GetProductionBugsAsync();
        }
        
        public int GetTotalTimeSpent(string subTaskKey, System.DateTime from, System.DateTime to) {
            return base.Channel.GetTotalTimeSpent(subTaskKey, from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalTimeSpentAsync(string subTaskKey, System.DateTime from, System.DateTime to) {
            return base.Channel.GetTotalTimeSpentAsync(subTaskKey, from, to);
        }
    }
}
