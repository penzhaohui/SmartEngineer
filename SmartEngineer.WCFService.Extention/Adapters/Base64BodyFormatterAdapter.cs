using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;

namespace SmartEngineer.WCFService.Ext.Adapters
{ 
    /// <summary>
  /// 这个Formatter能将消息的正文转换成base64字符串,这样做的好处是能混淆正文内容。对消息安全有好处
  /// </summary>
    public class Base64BodyFormatterAdapter : IClientMessageFormatter, IDispatchMessageFormatter
    {
        private IClientMessageFormatter _innerClientFormatter;
        private IDispatchMessageFormatter _innerDispatchFormatter;

        private Message ToBase64BodyMessage(Message meesage)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(memoryStream, Encoding.UTF8);
            meesage.WriteBodyContents(writer);
            writer.Flush();

            string body = System.Text.Encoding.UTF8.GetString(memoryStream.GetBuffer());
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(body);
            body = Convert.ToBase64String(buffer);
            Message newMessage = Message.CreateMessage(meesage.Version, meesage.Headers.Action, new MessageBodyWriter(body));
            meesage.Close();

            return newMessage;
        }

        private Message FormBase64Message(Message message)
        {
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(ms, Encoding.UTF8);
            message.WriteBody(writer);
            writer.Flush();

            string body = System.Text.Encoding.UTF8.GetString(ms.GetBuffer());
            int index = body.IndexOf(">");
            int index2 = body.IndexOf("</");
            body = body.Substring(index + 1, index2 - index - 1);
            byte[] buffer2 = Convert.FromBase64String(body);
            body = System.Text.Encoding.UTF8.GetString(buffer2);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(body);

            Message originMessage = Message.CreateMessage(message.Version, message.Headers.Action, new MessageBodyWriter(doc));
            originMessage.Headers.FaultTo = message.Headers.FaultTo;
            originMessage.Headers.From = message.Headers.From;
            originMessage.Headers.MessageId = message.Headers.MessageId;
            originMessage.Headers.RelatesTo = message.Headers.RelatesTo;
            originMessage.Headers.ReplyTo = message.Headers.ReplyTo;
            originMessage.Headers.To = message.Headers.To;

            foreach (var mh in message.Headers)
            {
                if (mh is MessageHeader)
                {
                    if (mh.Name != "Action" && mh.Name != "FaultTo" && mh.Name != "From" && mh.Name != "MessageID" && mh.Name != "RelatesTo" && mh.Name != "ReplyTo" && mh.Name != "To")
                    {
                        originMessage.Headers.Add(mh as MessageHeader);
                    }
                }
            }
            originMessage.Properties.Clear();
            foreach (var p in message.Properties)
            {
                originMessage.Properties[p.Key] = p.Value;
            }
            return originMessage;
        }

        public Base64BodyFormatterAdapter(IClientMessageFormatter formatter)
        {
            this._innerClientFormatter = formatter;
        }
        public Base64BodyFormatterAdapter(IDispatchMessageFormatter formatter)
        {
            this._innerDispatchFormatter = formatter;
        }

        #region 实现IClientMessageFormatter成员，格式化客户端中的消息

        public object DeserializeReply(System.ServiceModel.Channels.Message message, object[] parameters)
        {
            Message origin = FormBase64Message(message);
            message = origin;
            return _innerClientFormatter.DeserializeReply(origin, parameters);
        }

        public System.ServiceModel.Channels.Message SerializeRequest(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters)
        {
            Message origin = _innerClientFormatter.SerializeRequest(messageVersion, parameters);
            return ToBase64BodyMessage(origin);
        }

        #endregion

        #region 实现IDispatchMessageFormatter成员,格式化服务端消息

        public void DeserializeRequest(System.ServiceModel.Channels.Message message, object[] parameters)
        {
            Message origin = FormBase64Message(message);
            message = origin;
            _innerDispatchFormatter.DeserializeRequest(origin, parameters);            
        }

        public System.ServiceModel.Channels.Message SerializeReply(System.ServiceModel.Channels.MessageVersion messageVersion, object[] parameters, object result)
        {
            Message origin = _innerDispatchFormatter.SerializeReply(messageVersion, parameters, result);
            return ToBase64BodyMessage(origin);
        }

        #endregion
    }
}
