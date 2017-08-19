using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.WCFService.Ext.Behaviors
{
    public class BinaryFormatterEndpointBehavior : IEndpointBehavior
    {
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                DecorateFormatterBehavior(operation, clientRuntime);
            }
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (var operation in endpoint.Contract.Operations)
            {
                DecorateFormatterBehavior(operation, endpointDispatcher.DispatchRuntime);
            }
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void Validate(ServiceEndpoint endpoint) { }

        private static void DecorateFormatterBehavior(OperationDescription operation, object runtime)
        {
            //这个行为附加一次。 
            var dfBehavior = operation.Behaviors.Find<BinaryFormatterOperationBehavior>();
            if (dfBehavior == null)
            {
                //装饰新的操作行为 
                //这个行为是操作的行为，但是我们期望只为当前终结点做操作的序列化，所以传入 runtime 进行区分。
                dfBehavior = new BinaryFormatterOperationBehavior(runtime);
                operation.Behaviors.Add(dfBehavior);
            }
        }
    }

}
