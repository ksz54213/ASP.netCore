using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.net_core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       public Startup(){
           Program.Output("Startup Constructor - Called");
       }
        public void ConfigureServices(IServiceCollection services)
        {
            Program.Output("ConfigureServices - Called");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , IApplicationLifetime appLifetime)
        {
         /*    if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });   */

            appLifetime.ApplicationStarted.Register(() => 
            {
                Program.Output("ApplicationLifetime - Started");
            });
            
            appLifetime.ApplicationStopping.Register(()=>
            {
                Program.Output("ApplicationLifetime - Stopping");
            });

            appLifetime.ApplicationStopped.Register(()=>
            
            {
                Program.Output("ApplicationLifetime - Stopped");
            });

            app.Run(async (context)=>
            {
                await context.Response.WriteAsync("Hello world");
            });

            var thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(5*1000);
                Program.Output("Trigger stop WebHost");
                appLifetime.StopApplication();
            }));
            thread.Start();
            Program.Output("Startup.Configure - Called");
            
        }
    }
}
