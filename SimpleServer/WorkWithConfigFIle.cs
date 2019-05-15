using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SimpleServer
{
    class WorkWithConfigFIle
    {

        public int Port { get; set; }
        public string Path { get; set; }

        public void Read(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            // getting XML root element 
            XmlElement xRoot = xDoc.DocumentElement;
            // parsing all nodes in XML root element
            foreach (XmlNode xnode in xRoot)
            {
                // parsing all child nodes
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // working with node "port"
                    if (childnode.Name == "port")
                    {
                        this.Port = int.Parse(childnode.InnerText);
                    }
                    // working with node "path"
                    if (childnode.Name == "path")
                    {
                        this.Path = childnode.InnerText;
                    }
                }
            }
        }
        
    }
}
