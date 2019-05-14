using System;
using System.IO;
using System.Net;
using System.Text;

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
            // Starting server
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
                    byte[] buffer = Encoding.UTF8.GetBytes("<HTML><BODY> " + "It works!" + "</BODY></HTML>");
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                else
                {
                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;
                    // Sending response with status code 501
                    response.StatusCode = (int)HttpStatusCode.NotImplemented;
                    // Construct a response.
                    byte[] buffer = Encoding.UTF8.GetBytes("<HTML><BODY> " + "501 Not Implemented!" + "</BODY></HTML>");
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
