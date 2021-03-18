using SUS.HTTP;
using System;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
           

            server.AddRoute("/", HomePage);
            await server.StartAsync(80);
        }


        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }

   
}
