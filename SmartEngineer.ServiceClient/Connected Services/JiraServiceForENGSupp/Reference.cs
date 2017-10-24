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
    [System.Runtime.Serialization.DataContractAttribute(Name="IssueInfo", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    public partial class IssueInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByLabels(string[] labels);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabels", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByLabelsResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByLabelsAsync(string[] labels);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatuses", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatusesResponse")]
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByStatuses(string[] statuses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatuses", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByStatusesResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByStatusesAsync(string[] statuses);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNos", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNosResponse")]
        SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByCaseNos(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNos", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetIssuesByCaseNosResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByCaseNosAsync(string[] caseNOs);
        
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssueCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssueCountResponse")]
        int GetNewIssueCount(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssueCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetNewIssueCountResponse")]
        System.Threading.Tasks.Task<int> GetNewIssueCountAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssueCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssueCountResponse")]
        int GetResolvedIssueCount(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssueCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetResolvedIssueCountResponse")]
        System.Threading.Tasks.Task<int> GetResolvedIssueCountAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugCountResponse")]
        int GetProductionBugCount(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugCount", ReplyAction="http://tempuri.org/IJiraServiceForENGSupp/GetProductionBugCountResponse")]
        System.Threading.Tasks.Task<int> GetProductionBugCountAsync(System.DateTime from, System.DateTime to);
        
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
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByLabels(string[] labels) {
            return base.Channel.GetIssuesByLabels(labels);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByLabelsAsync(string[] labels) {
            return base.Channel.GetIssuesByLabelsAsync(labels);
        }
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByStatuses(string[] statuses) {
            return base.Channel.GetIssuesByStatuses(statuses);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByStatusesAsync(string[] statuses) {
            return base.Channel.GetIssuesByStatusesAsync(statuses);
        }
        
        public SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[] GetIssuesByCaseNos(string[] caseNOs) {
            return base.Channel.GetIssuesByCaseNos(caseNOs);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.JiraServiceForENGSupp.IssueInfo[]> GetIssuesByCaseNosAsync(string[] caseNOs) {
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
        
        public int GetNewIssueCount(System.DateTime from, System.DateTime to) {
            return base.Channel.GetNewIssueCount(from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetNewIssueCountAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetNewIssueCountAsync(from, to);
        }
        
        public int GetResolvedIssueCount(System.DateTime from, System.DateTime to) {
            return base.Channel.GetResolvedIssueCount(from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetResolvedIssueCountAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetResolvedIssueCountAsync(from, to);
        }
        
        public int GetProductionBugCount(System.DateTime from, System.DateTime to) {
            return base.Channel.GetProductionBugCount(from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetProductionBugCountAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetProductionBugCountAsync(from, to);
        }
        
        public int GetTotalTimeSpent(string subTaskKey, System.DateTime from, System.DateTime to) {
            return base.Channel.GetTotalTimeSpent(subTaskKey, from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetTotalTimeSpentAsync(string subTaskKey, System.DateTime from, System.DateTime to) {
            return base.Channel.GetTotalTimeSpentAsync(subTaskKey, from, to);
        }
    }
}
