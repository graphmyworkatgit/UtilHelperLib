using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace UtilHelper.XmlHelper
{
    public class XmlWriter
    {
        public int WiteDoc()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode rootNode = xmldoc.CreateElement("users");
            xmldoc.AppendChild(rootNode);

            XmlNode userNode = xmldoc.CreateElement("user");
            XmlAttribute attribute = xmldoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmldoc.CreateElement("user");
            attribute = xmldoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);
            var pathWithFilaName = "path"+"test-doc.xml";
            xmldoc.Save(pathWithFilaName);

            return -1;
        }
    }
}
