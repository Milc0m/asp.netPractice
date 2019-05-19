using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Security;

namespace SimpleServer
{
    class Config
    {
        public int Port { get; set; }
        
        public string Path { get; set; }

        // adding default path for config file
        public string defaultName = "serverconfig.xml";
        
        // Creating defoultt XML file
        public void Create()
        {
            XDocument xdoc = new XDocument();
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
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Don't have permission to create default config file.");
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
                    Console.WriteLine("Enter valid information about port.");
                    Exit();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Please enter port number.");
                    Exit();
                }
                if (Port < 0 && Port > 65536)
                {
                    Console.WriteLine("Port number must be between 0-65536");
                    Exit();
                }

                try
                {
                    this.Path = xDoc.Root.Element("path").Value;
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine("Please enter path to webfiles dir.");
                    Exit();
                }
            }
            catch (XmlException)
            {
                Console.WriteLine("Config file is empty or it can't be read!");
                Exit();
            }
            catch (SecurityException)
            {
                Console.WriteLine("Can't access to the location of the XML data! Need more permissions!");
                Exit();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Can't find file in inputted location!");
                Exit();
            }
        }

        public void Exit()
        {
            Console.WriteLine("Program will be close.");
            // Delay
            Console.ReadKey();
            Environment.Exit(-1);
        }
    }
}
