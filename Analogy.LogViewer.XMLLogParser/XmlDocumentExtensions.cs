using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Analogy.LogViewer.XMLParser
{
    public static class XmlDocumentExtensions
    {
        public static void IterateThroughAllNodes(
            this XmlDocument doc,
            Action<XmlNode> elementVisitor)
        {
            if (doc != null && elementVisitor != null)
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    foreach (XmlNode inner in node.ChildNodes)
                    {
                        elementVisitor(inner);
                    }

                    //doIterateNode(inner, elementVisitor);
                }
            }
        }

        private static void doIterateNode(
            XmlNode node,
            Action<XmlNode> elementVisitor)
        {
            elementVisitor(node);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                doIterateNode(childNode, elementVisitor);
            }
        }
    }
}