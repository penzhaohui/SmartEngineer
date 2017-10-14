﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartEngineer.ServiceClient.SalesforceService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CaseInfo", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    public partial class CaseInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SalesforceService.ISalesforceService")]
    public interface ISalesforceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetNewCasesList", ReplyAction="http://tempuri.org/ISalesforceService/GetNewCasesListResponse")]
        SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetNewCasesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetNewCasesList", ReplyAction="http://tempuri.org/ISalesforceService/GetNewCasesListResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetNewCasesListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCommentedCasesList", ReplyAction="http://tempuri.org/ISalesforceService/GetCommentedCasesListResponse")]
        SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetCommentedCasesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCommentedCasesList", ReplyAction="http://tempuri.org/ISalesforceService/GetCommentedCasesListResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetCommentedCasesListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCasesByCaseNOs", ReplyAction="http://tempuri.org/ISalesforceService/GetCasesByCaseNOsResponse")]
        SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetCasesByCaseNOs(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCasesByCaseNOs", ReplyAction="http://tempuri.org/ISalesforceService/GetCasesByCaseNOsResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetCasesByCaseNOsAsync(string[] caseNOs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetProcessedCase", ReplyAction="http://tempuri.org/ISalesforceService/GetProcessedCaseResponse")]
        SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetProcessedCase(System.DateTime from, System.DateTime to, string[] sfAccounts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetProcessedCase", ReplyAction="http://tempuri.org/ISalesforceService/GetProcessedCaseResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetProcessedCaseAsync(System.DateTime from, System.DateTime to, string[] sfAccounts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetTotalNewCaseCount", ReplyAction="http://tempuri.org/ISalesforceService/GetTotalNewCaseCountResponse")]
        int GetTotalNewCaseCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetTotalNewCaseCount", ReplyAction="http://tempuri.org/ISalesforceService/GetTotalNewCaseCountResponse")]
        System.Threading.Tasks.Task<int> GetTotalNewCaseCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCaseCommentCount", ReplyAction="http://tempuri.org/ISalesforceService/GetCaseCommentCountResponse")]
        int GetCaseCommentCount(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetCaseCommentCount", ReplyAction="http://tempuri.org/ISalesforceService/GetCaseCommentCountResponse")]
        System.Threading.Tasks.Task<int> GetCaseCommentCountAsync(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetReviewedCaseCount", ReplyAction="http://tempuri.org/ISalesforceService/GetReviewedCaseCountResponse")]
        int GetReviewedCaseCount(System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesforceService/GetReviewedCaseCount", ReplyAction="http://tempuri.org/ISalesforceService/GetReviewedCaseCountResponse")]
        System.Threading.Tasks.Task<int> GetReviewedCaseCountAsync(System.DateTime from, System.DateTime to);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISalesforceServiceChannel : SmartEngineer.ServiceClient.SalesforceService.ISalesforceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SalesforceServiceClient : System.ServiceModel.ClientBase<SmartEngineer.ServiceClient.SalesforceService.ISalesforceService>, SmartEngineer.ServiceClient.SalesforceService.ISalesforceService {
        
        public SalesforceServiceClient() {
        }
        
        public SalesforceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SalesforceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesforceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesforceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetNewCasesList() {
            return base.Channel.GetNewCasesList();
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetNewCasesListAsync() {
            return base.Channel.GetNewCasesListAsync();
        }
        
        public SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetCommentedCasesList() {
            return base.Channel.GetCommentedCasesList();
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetCommentedCasesListAsync() {
            return base.Channel.GetCommentedCasesListAsync();
        }
        
        public SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetCasesByCaseNOs(string[] caseNOs) {
            return base.Channel.GetCasesByCaseNOs(caseNOs);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetCasesByCaseNOsAsync(string[] caseNOs) {
            return base.Channel.GetCasesByCaseNOsAsync(caseNOs);
        }
        
        public SmartEngineer.ServiceClient.SalesforceService.CaseInfo[] GetProcessedCase(System.DateTime from, System.DateTime to, string[] sfAccounts) {
            return base.Channel.GetProcessedCase(from, to, sfAccounts);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SalesforceService.CaseInfo[]> GetProcessedCaseAsync(System.DateTime from, System.DateTime to, string[] sfAccounts) {
            return base.Channel.GetProcessedCaseAsync(from, to, sfAccounts);
        }
        
        public int GetTotalNewCaseCount() {
            return base.Channel.GetTotalNewCaseCount();
        }
        
        public System.Threading.Tasks.Task<int> GetTotalNewCaseCountAsync() {
            return base.Channel.GetTotalNewCaseCountAsync();
        }
        
        public int GetCaseCommentCount(System.DateTime from, System.DateTime to) {
            return base.Channel.GetCaseCommentCount(from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetCaseCommentCountAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetCaseCommentCountAsync(from, to);
        }
        
        public int GetReviewedCaseCount(System.DateTime from, System.DateTime to) {
            return base.Channel.GetReviewedCaseCount(from, to);
        }
        
        public System.Threading.Tasks.Task<int> GetReviewedCaseCountAsync(System.DateTime from, System.DateTime to) {
            return base.Channel.GetReviewedCaseCountAsync(from, to);
        }
    }
}
