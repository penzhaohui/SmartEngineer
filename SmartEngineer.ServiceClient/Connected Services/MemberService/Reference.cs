﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartEngineer.ServiceClient.MemberService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MemberService.IMemberService")]
    public interface IMemberService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberService/DoWork", ReplyAction="http://tempuri.org/IMemberService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemberService/DoWork", ReplyAction="http://tempuri.org/IMemberService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMemberServiceChannel : SmartEngineer.ServiceClient.MemberService.IMemberService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MemberServiceClient : System.ServiceModel.ClientBase<SmartEngineer.ServiceClient.MemberService.IMemberService>, SmartEngineer.ServiceClient.MemberService.IMemberService {
        
        public MemberServiceClient() {
        }
        
        public MemberServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MemberServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemberServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemberServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
    }
}
