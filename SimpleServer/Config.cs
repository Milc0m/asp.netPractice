using System.Xml;
using System.Xml.Linq;

namespace SimpleServer
{
    class Config
    {
        public int Port { get; set; }
        public string Path { get; set; }

        // adding defoult path for config file(for correct work his string must be changed due to local properties after cloning)
        public string defoultPath = "D:\\github\\SimpleServer\\SimpleServer\\bin\\Debug\\netcoreapp2.1\\serverconfig.xml";

        // Creating defoultt XML file
        public void Create()
        {
            XDocument xdoc = new XDocument();
            //// creating XML attribute
            XElement portNumberElem = new XElement("port", "60000");
            XElement pathtoWedDirElem = new XElement("path", "\\Web Files\\");
            // creating XML root element
            XElement parameters = new XElement("parameters");
            // adding to XML root element
            parameters.Add(portNumberElem);
            parameters.Add(pathtoWedDirElem);
            // adding XML root element to document
            xdoc.Add(parameters);
            // saving document
            xdoc.Save("serverconfig.xml");
        }

        // Reading XML file
        public void Read(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            // getting XML root element 
            XmlElement xRoot = xDoc.DocumentElement;
            // parsing all nodes in XML root element
            foreach (XmlNode xnode in xRoot)
            {
                // working with node "port"
                if (xnode.Name == "port")
                {
                    this.Port = int.Parse(xnode.InnerText);
                }
                // working with node "path"
                if (xnode.Name == "path")
                {
                    this.Path = xnode.InnerText;
                }
            }
        }
    }
}
