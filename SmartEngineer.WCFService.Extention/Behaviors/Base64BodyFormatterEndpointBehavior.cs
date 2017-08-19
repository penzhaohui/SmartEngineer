using SmartEngineer.WCFService.Ext.Inspectors;
using System.ServiceModel.Description;

namespace SmartEngineer.WCFService.Ext.Behaviors
{
    public class Base64BodyFormatterEndpointBehavior : IEndpointBehavior
    {

        #region IEndpointBehavior 成员

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MessageInspector());
        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        #endregion
    }
}
