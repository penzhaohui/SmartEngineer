using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;
using System.Reflection;

namespace SmartEngineer.WCFService.Ext.Adapters
{
    /// <summary> 
    /// 在内部序列化器的基础上添加 Remoting 二进制序列化的功能。 
    /// </summary> 
    public class BinaryFormatterAdapter : IClientMessageFormatter, IDispatchMessageFormatter
    {
        private IClientMessageFormatter _innerClientFormatter;
        private IDispatchMessageFormatter _innerDispatchFormatter;
        private ParameterInfo[] _parameterInfos;
        private string _operationName;
        private string _action;

        /// <summary> 
        /// for client 
        /// </summary> 
        /// <param name="operationName"></param> 
        /// <param name="parameterInfos"></param> 
        /// <param name="innerClientFormatter"></param> 
        /// <param name="action"></param> 
        public BinaryFormatterAdapter(
            string operationName,
            ParameterInfo[] parameterInfos,
            IClientMessageFormatter innerClientFormatter,
            string action
            )
        {
            if (operationName == null) throw new ArgumentNullException("methodName");
            if (parameterInfos == null) throw new ArgumentNullException("parameterInfos");
            if (innerClientFormatter == null) throw new ArgumentNullException("innerClientFormatter");
            if (action == null) throw new ArgumentNullException("action");

            this._innerClientFormatter = innerClientFormatter;
            this._parameterInfos = parameterInfos;
            this._operationName = operationName;
            this._action = action;
        }

        /// <summary> 
        /// for server 
        /// </summary> 
        /// <param name="operationName"></param> 
        /// <param name="parameterInfos"></param> 
        /// <param name="innerDispatchFormatter"></param> 
        public BinaryFormatterAdapter(
            string operationName,
            ParameterInfo[] parameterInfos,
            IDispatchMessageFormatter innerDispatchFormatter
            )
        {
            if (operationName == null) throw new ArgumentNullException("operationName");
            if (parameterInfos == null) throw new ArgumentNullException("parameterInfos");
            if (innerDispatchFormatter == null) throw new ArgumentNullException("innerDispatchFormatter");

            this._innerDispatchFormatter = innerDispatchFormatter;
            this._operationName = operationName;
            this._parameterInfos = parameterInfos;
        }

        Message IClientMessageFormatter.SerializeRequest(MessageVersion messageVersion, object[] parameters)
        {
            var result = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++) { result[i] = Serializer.SerializeBytes(parameters[i]); }

            return _innerClientFormatter.SerializeRequest(messageVersion, result);
        }

        #region 实现IClientMessageFormatter成员，序列化客户端中的消息

        object IClientMessageFormatter.DeserializeReply(Message message, object[] parameters)
        {
            var result = _innerClientFormatter.DeserializeReply(message, parameters);

            for (int i = 0; i < parameters.Length; i++) { parameters[i] = Serializer.DeserializeBytes(parameters[i] as byte[]); }
            result = Serializer.DeserializeBytes(result as byte[]);

            return result;
        }

        void IDispatchMessageFormatter.DeserializeRequest(Message message, object[] parameters)
        {
            _innerDispatchFormatter.DeserializeRequest(message, parameters);

            for (int i = 0; i < parameters.Length; i++) { parameters[i] = Serializer.DeserializeBytes(parameters[i] as byte[]); }
        }

        #endregion

        #region 实现IDispatchMessageFormatter成员,序列化服务端消息

        Message IDispatchMessageFormatter.SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            var seralizedParameters = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++) { seralizedParameters[i] = Serializer.SerializeBytes(parameters[i]); }
            var serialzedResult = Serializer.SerializeBytes(result);

            return _innerDispatchFormatter.SerializeReply(messageVersion, seralizedParameters, serialzedResult);
        }

        #endregion
    }
}
