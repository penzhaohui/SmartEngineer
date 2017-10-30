using SmartEngineer.WCFService.Ext.Handlers;
using SmartEngineer.WCFService.Ext.Inspectors;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SmartEngineer.WCFService.Ext.Behaviors
{
    public class GlobalEndpointBehavior : IEndpointBehavior
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

            ChannelDispatcher cndisp = endpointDispatcher.ChannelDispatcher;

            // 加入自定义的错误处理程序
            GlobalErrorHandler cehdlr = null;
            cehdlr = (GlobalErrorHandler)cndisp.ErrorHandlers.FirstOrDefault();
            if (cehdlr == null)
            {
                cehdlr = new GlobalErrorHandler();
            }
            cndisp.ErrorHandlers.Add(cehdlr);
        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        #endregion
    }
}
