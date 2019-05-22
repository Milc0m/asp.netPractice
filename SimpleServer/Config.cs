using System;
using System.IO;
using System.Xml.Linq;
using System.Security;

namespace SimpleServer
{
    class Config
    {
        public int Port { get; set; }
        
        public string Path { get; set; }

        // adding default path for config file
        public string defaultName = "serverconfig.xml";
        
        // Creating default XML file
        public void Create()
        {
            XDocument xdoc = new XDocument();
            //default server port 60000
            XElement portNumberElem = new XElement("port", "60000");
            XElement pathtoWedDirElem = new XElement("path", "\\Web Files\\");
            // creating XML root element
            XElement parameters = new XElement("parameters");
            parameters.Add(portNumberElem);
            parameters.Add(pathtoWedDirElem);
            // adding XML root element to document
            xdoc.Add(parameters);
            try
            {
                xdoc.Save("serverconfig.xml");
            }
            catch (SecurityException)
            {
                PrintErrorAndExit("Don't have permission to create default config file.");
            }
        }

        // Reading XML file
        public void Read(string pathToFile)
        {
            // Parsing input information
            try
            {
                XDocument xDoc = XDocument.Load(pathToFile);
                try
                {
                    this.Port = int.Parse(xDoc.Root.Element("port").Value);
                    
                }
                catch (FormatException)
                {
                    PrintErrorAndExit("Missing port number in config file.");
                }
                catch (NullReferenceException)
                {
                    PrintErrorAndExit("Missing port number in config file.");
                }
                if (Port < 0 && Port > 65536)
                {
                    PrintErrorAndExit("Port number must be between 0-65536");
                }

                try
                {
                    this.Path = xDoc.Root.Element("path").Value;
                }
                catch(NullReferenceException)
                {
                    PrintErrorAndExit("Please enter path to webfiles dir.");
                }
            }
            catch (SecurityException)
            {
                PrintErrorAndExit("Error! Can't access to the location of the XML data! Need more permissions!");
            }
            catch (FileNotFoundException)
            {
                PrintErrorAndExit("Can't find file in inputted location!");
            }
        }

        public void PrintErrorAndExit(string message)
        {
            Console.WriteLine("Error! " + message + " Program will be close.");
            // Delay
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
