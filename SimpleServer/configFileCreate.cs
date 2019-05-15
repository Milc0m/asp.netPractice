using System.Xml.Linq;

namespace SimpleServer
{
    class ConfigFileCreate
    {
        // adding defoult path for config file(for correct work his string must be changed due to local properties after cloning)
        public string defoultPath = "D:\\github\\SimpleServer\\SimpleServer\\bin\\Debug\\netcoreapp2.1\\config.xml";

        public void Create()
        {
            XDocument xdoc = new XDocument();
            // creating XML element
            XElement serverParametr = new XElement("serverParameter");
            // creating XML attribute
            XElement portNumberElem = new XElement("port", "60000");
            XElement pathtoWedDirElem = new XElement("path", "\\Web Files\\");
            // adding attribute to element
            serverParametr.Add(portNumberElem);
            serverParametr.Add(pathtoWedDirElem);
            // creating XML root element
            XElement parameters = new XElement("parameters");
            // adding to XML root element
            parameters.Add(serverParametr);
            // adding XML root element to document
            xdoc.Add(parameters);
            // saving document
            xdoc.Save("config.xml");
        }
    }
}
