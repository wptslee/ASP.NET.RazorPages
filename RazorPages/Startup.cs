using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPages.Services;

namespace RazorPages
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(); // Razor
            services.AddServerSideBlazor(); // Blazor

            //-------------------------------------------------------------
            //- Dependency-Injection Container
            //services.AddSingleton<PortfolioServiceJsonFile>();
            //services.AddScoped<PortfolioServiceJsonFile>();
            services.AddTransient<PortfolioServiceJsonFile>(); // new PortfolioServiceJsonFile()

            //-------------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add Middleware
            app.UseStaticFiles(); // static HTML, CSS, JavaScript Execute
            //app.UseFileServer(); // "Microsoft Docs UseFileServer"

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Razor
                endpoints.MapBlazorHub(); // Blazor
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
