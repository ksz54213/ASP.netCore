using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASP.net_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Output("Application - Start");
            var webHost = BuildWebHost(args);
            webHost.Run();
            Output("Application -End");

        }
        public static IWebHost BuildWebHost(string[] args){
            Output("Create WebHost Builder");
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(services => 
            {
                Output("webHostBuilder.ConfigureServices");
            })
            .Configure(app=>
            {
                Output("webHostBuilder.Configure - Called");
            })
            .UseStartup<Startup>();
            Output("Buidl WebHost");
            var webHost = webHostBuilder.Build();
            return webHost;
        }
        /* public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        */
        public static void Output(string message){
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}]");
        }
    }
}
