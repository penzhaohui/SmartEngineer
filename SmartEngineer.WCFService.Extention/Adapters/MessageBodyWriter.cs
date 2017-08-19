using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmartEngineer.WCFService.Ext.Adapters
{
    internal class MessageBodyWriter : BodyWriter
    {
        string body = "";
        XmlDocument doc;
        public MessageBodyWriter(string body)
            : base(true)
        {
            this.body = body;
        }

        public MessageBodyWriter(XmlDocument doc)
            : base(true)
        {
            this.doc = doc;
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.NewLineHandling = NewLineHandling.Entitize;
            setting.CheckCharacters = false;

            if (!string.IsNullOrEmpty(body))
            {
                writer.WriteRaw(body);
            }

            if (doc != null)
            {
                doc.WriteContentTo(writer);
                writer.Flush();
            }
        }
    }
}
