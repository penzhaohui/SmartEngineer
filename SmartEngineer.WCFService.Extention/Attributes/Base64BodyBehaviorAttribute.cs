using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using SmartEngineer.WCFService.Ext.Adapters;

namespace SmartEngineer.WCFService.Ext.Attributes
{
    public class Base64BodyBehaviorAttribute : Attribute, IOperationBehavior
    {
        #region IOperationBehavior 成员

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
            clientOperation.SerializeRequest = true;
            clientOperation.DeserializeReply = true;
            clientOperation.Formatter = new Base64BodyFormatterAdapter(clientOperation.Formatter);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            dispatchOperation.DeserializeRequest = true;
            dispatchOperation.SerializeReply = true;
            dispatchOperation.Formatter = new Base64BodyFormatterAdapter(dispatchOperation.Formatter);
        }

        public void Validate(OperationDescription operationDescription)
        {

        }

        #endregion
    }
}
