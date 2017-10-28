using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SmartEngineer.WCFService.Ext.Handlers
{
    // https://www.codeproject.com/Articles/899342/WCF-Global-Exception-Handling
    public class GlobalErrorHandler : IErrorHandler
    {
        /// <summary>
        /// The method that's get invoked if any unhandled exception raised in service
        /// Here you can do what ever logic you would like to. 
        /// For example logging the exception details
        /// Here the return value indicates that the exception was handled or not
        /// Return true to stop exception propagation and system considers 
        /// that the exception was handled properly
        /// else return false to abort the session
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool HandleError(Exception error)
        {
            // The socket connection was aborted
            // http://blog.csdn.net/zerokiseki/article/details/7735449
            System.Console.WriteLine(error.Message);
            return true;
        }

        /// <summary>
        /// If you want to communicate the exception details to the service client 
        /// as proper fault message
        /// here is the place to do it
        /// If we want to suppress the communication about the exception, 
        /// set fault to null
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error,
            System.ServiceModel.Channels.MessageVersion version,
            ref System.ServiceModel.Channels.Message fault)
        {
            var newEx = new FaultException(
                string.Format("Exception caught at Service Application GlobalErrorHandler{0}Method: {1}{2} Message: {3}",
                Environment.NewLine, error.TargetSite.Name, 
                Environment.NewLine, error.Message));

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}
