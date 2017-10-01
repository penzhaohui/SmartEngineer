using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfluenceClient.Confluence
{
    public class Storage
    {
        public string value { get; set; }
        public string representation { get; set; }

        public void UpdateMacroContent(string name, string newContent)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("ac", "urn:macro");

            //Loading the content as XML sometimes doesnt work, i.e. unforseen namespaces used
            try
            {
                string newValue = value.Replace("&nbsp;", "&#160;");
                xmlDoc.LoadXml("<root xmlns:ac=\"urn:macro\">" + newValue + "</root>");
            }
            catch (Exception ex)
            {
                throw new Exception("Could not load content of Page as an XmlDocument", ex);
            }

            //Find the macro with the particular name
            XmlNode node = xmlDoc.SelectSingleNode("//ac:structured-macro[@ac:name='" + name + "']", nsmgr);
            if (node == null)
                throw new Exception("Macro with name " + name + " cannot be found");

            if (node.Name == "ac:structured-macro" && node.Attributes["ac:name"].Value == name)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    if (childnode.Name == "ac:rich-text-body")
                    {
                        childnode.InnerXml = newContent;
                    }
                }
            }

            value = xmlDoc.DocumentElement.InnerXml;
        }
    }

}
