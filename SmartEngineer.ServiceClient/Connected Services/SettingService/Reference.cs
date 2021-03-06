﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartEngineer.ServiceClient.SettingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConfigOption", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    public partial class ConfigOption : SmartEngineer.ServiceClient.SettingService.BasicDataModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConfigExtraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ConfigIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConfigOptionDescField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConfigOptionValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TenantIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ConfigExtra {
            get {
                return this.ConfigExtraField;
            }
            set {
                if ((object.ReferenceEquals(this.ConfigExtraField, value) != true)) {
                    this.ConfigExtraField = value;
                    this.RaisePropertyChanged("ConfigExtra");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ConfigID {
            get {
                return this.ConfigIDField;
            }
            set {
                if ((this.ConfigIDField.Equals(value) != true)) {
                    this.ConfigIDField = value;
                    this.RaisePropertyChanged("ConfigID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ConfigOptionDesc {
            get {
                return this.ConfigOptionDescField;
            }
            set {
                if ((object.ReferenceEquals(this.ConfigOptionDescField, value) != true)) {
                    this.ConfigOptionDescField = value;
                    this.RaisePropertyChanged("ConfigOptionDesc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ConfigOptionValue {
            get {
                return this.ConfigOptionValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ConfigOptionValueField, value) != true)) {
                    this.ConfigOptionValueField = value;
                    this.RaisePropertyChanged("ConfigOptionValue");
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
        public bool IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TenantID {
            get {
                return this.TenantIDField;
            }
            set {
                if ((this.TenantIDField.Equals(value) != true)) {
                    this.TenantIDField = value;
                    this.RaisePropertyChanged("TenantID");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasicDataModel", Namespace="http://schemas.datacontract.org/2004/07/SmartEngineer.Core.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SmartEngineer.ServiceClient.SettingService.ConfigOption))]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SettingService.ISettingService")]
    public interface ISettingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetAllConfigs", ReplyAction="http://tempuri.org/ISettingService/GetAllConfigsResponse")]
        SmartEngineer.ServiceClient.SettingService.ConfigOption[] GetAllConfigs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetAllConfigs", ReplyAction="http://tempuri.org/ISettingService/GetAllConfigsResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SettingService.ConfigOption[]> GetAllConfigsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetConfigOptions", ReplyAction="http://tempuri.org/ISettingService/GetConfigOptionsResponse")]
        SmartEngineer.ServiceClient.SettingService.ConfigOption[] GetConfigOptions(string configName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetConfigOptions", ReplyAction="http://tempuri.org/ISettingService/GetConfigOptionsResponse")]
        System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SettingService.ConfigOption[]> GetConfigOptionsAsync(string configName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/UpdateConfigOptions", ReplyAction="http://tempuri.org/ISettingService/UpdateConfigOptionsResponse")]
        bool UpdateConfigOptions(string configName, SmartEngineer.ServiceClient.SettingService.ConfigOption[] options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/UpdateConfigOptions", ReplyAction="http://tempuri.org/ISettingService/UpdateConfigOptionsResponse")]
        System.Threading.Tasks.Task<bool> UpdateConfigOptionsAsync(string configName, SmartEngineer.ServiceClient.SettingService.ConfigOption[] options);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISettingServiceChannel : SmartEngineer.ServiceClient.SettingService.ISettingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SettingServiceClient : System.ServiceModel.ClientBase<SmartEngineer.ServiceClient.SettingService.ISettingService>, SmartEngineer.ServiceClient.SettingService.ISettingService {
        
        public SettingServiceClient() {
        }
        
        public SettingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SettingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SmartEngineer.ServiceClient.SettingService.ConfigOption[] GetAllConfigs() {
            return base.Channel.GetAllConfigs();
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SettingService.ConfigOption[]> GetAllConfigsAsync() {
            return base.Channel.GetAllConfigsAsync();
        }
        
        public SmartEngineer.ServiceClient.SettingService.ConfigOption[] GetConfigOptions(string configName) {
            return base.Channel.GetConfigOptions(configName);
        }
        
        public System.Threading.Tasks.Task<SmartEngineer.ServiceClient.SettingService.ConfigOption[]> GetConfigOptionsAsync(string configName) {
            return base.Channel.GetConfigOptionsAsync(configName);
        }
        
        public bool UpdateConfigOptions(string configName, SmartEngineer.ServiceClient.SettingService.ConfigOption[] options) {
            return base.Channel.UpdateConfigOptions(configName, options);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateConfigOptionsAsync(string configName, SmartEngineer.ServiceClient.SettingService.ConfigOption[] options) {
            return base.Channel.UpdateConfigOptionsAsync(configName, options);
        }
    }
}
