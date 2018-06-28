using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareDemo.Middleware;

namespace MiddlewareDemo
{
    public class Startup
    {
        private const string FileName = "log.txt";
        private const string TokenPattern = "123";

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/index", Index);
            app.Run(async context =>
            {
                await context.Response.WriteAsync("<h1>Page Not Found!</h1>");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.UseHandleError();
            app.UseLogRequest(FileName);
            app.UseAuthorize(TokenPattern);
            app.UseUserHeader();
            app.UseTimesOfDay();
        }
    }
}