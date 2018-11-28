using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace work2_MiddleWare_
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async(context , next) =>
            {
                await context.Response.WriteAsync("First MiddleWare in. \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("First MiddleWare out. \r\n");
            });

             app.Use(async(context , next) =>
            {
                await context.Response.WriteAsync("Second MiddleWare in. \r\n");
                
                /* if(false){ // 攔截
                    await next.Invoke();
                }*/
                await next.Invoke();
                await context.Response.WriteAsync("Second MiddleWare out. \r\n");
            }); 
            app.Map("/second",mapApp=>{ //set arg in url
                mapApp.Use(async(context,next)=>{
                        await context.Response.WriteAsync("Map MiddleWare in .\r\n");
                        await next.Invoke();
                        await context.Response.WriteAsync("Map MiddleWae out. \r\n");
                });

                mapApp.Run(async (context)=>
                {
                    await context.Response.WriteAsync("Fuck the lowest level ");
                });
            });

             app.Use(async(context , next) =>
            {
                await context.Response.WriteAsync("Third MiddleWare in. \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Third MiddleWare out. \r\n");
            });

            app.Run(async (context)=>{
                await context.Response.WriteAsync("Hellod world\r\n");
            }); 
        }
    }
}
