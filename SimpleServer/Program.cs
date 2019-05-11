using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using  System.Web;

namespace SimpleServer
{
    class Program
    {
        // Creating server
        private static readonly HttpListener MyServer = new HttpListener();

        static void Main()
        {
            // Adding server to port 30000
            MyServer.Prefixes.Add("http://127.0.0.1:30000/");
            // Sarting server
            MyServer.Start();

            Console.WriteLine("Listen.....");

            while (MyServer.IsListening)
            {
                //Waiting for incoming request
                HttpListenerContext context = MyServer.GetContext();
                //Getting incoming request 
                HttpListenerRequest request = context.Request;
                //working with Get request
                if (request.HttpMethod == "GET")
                {
                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;
                    // Construct a response.
                    string clientInformation = "Test";
                    byte[] buffer = Encoding.UTF8.GetBytes("<HTML><BODY> " + clientInformation + "</BODY></HTML>");
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                else
                {
                    // Text for output in html page
                    int Code = 501;
                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;
                    // Sending response with status code 501
                    response.StatusCode = (int)HttpStatusCode.NotImplemented;
                    // Construct a response.
                    string CodeStr = Code.ToString() + " " + ((HttpStatusCode)Code).ToString();
                    byte[] buffer = Encoding.UTF8.GetBytes("<HTML><BODY> " + CodeStr + "</BODY></HTML>");
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }

            }
        }
    }
}
