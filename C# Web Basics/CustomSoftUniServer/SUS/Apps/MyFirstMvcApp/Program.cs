using SUS.HTTP;
using System;

namespace MyFirstMvcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer();
            server.Start(80);

            server.AddRoute("/", HomePage);
        }

        static HttpResponse HomePage(HttpRequest request)
        {

        }
    }

   
}
