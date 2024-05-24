using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StardewSaveEditor.StardewValley
{
    internal class XmlTools
    {
        public static void ReplaceNodeContent(XmlDocument xmlDoc, XmlNode targetNode, XmlNode sourceNode)
        {
            targetNode.RemoveAll();

            foreach (XmlAttribute attr in sourceNode.Attributes)
            {
                XmlAttribute newAttr = xmlDoc.CreateAttribute(attr.Name);
                newAttr.Value = attr.Value;
                targetNode.Attributes.Append(newAttr);
            }
            foreach (XmlNode childNode in sourceNode.ChildNodes)
            {
                XmlNode newChildNode = xmlDoc.ImportNode(childNode, true);
                targetNode.AppendChild(newChildNode);
            }
        }

        public static void RenameNode(XmlDocument xmlDoc, XmlNode oldNode, string newName)
        {
            XmlNode newNode = xmlDoc.CreateElement(newName);
            ReplaceNodeContent(xmlDoc, newNode, oldNode);
            oldNode.ParentNode.ReplaceChild(newNode, oldNode);
        }

        public static void ExchangeNodeContent(XmlDocument xmlDoc, XmlNode nodeA, XmlNode nodeB)
        {
            XmlNode tempNode = xmlDoc.CreateElement(nodeA.LocalName);
            ReplaceNodeContent(xmlDoc, tempNode, nodeA);
            ReplaceNodeContent(xmlDoc, nodeA, nodeB);
            ReplaceNodeContent(xmlDoc, nodeB, tempNode);
        }
        public static XmlDocument GetXmlDock(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            FileStream fsXml = new FileStream(path, FileMode.Open);

            xmlDoc.Load(fsXml);

            fsXml.Close();

            return xmlDoc;
        }
    }
}
