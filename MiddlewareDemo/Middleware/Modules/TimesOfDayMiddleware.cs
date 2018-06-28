using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware.Modules
{
    public class TimesOfDayMiddleware
    {
        private readonly RequestDelegate _next;

        public TimesOfDayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var date = DateTime.Now;
            var greeting = date.Hour <= 5 
                ? "Good night!" 
                : (date.Hour <= 12 ? "Good morning!" : (date.Hour <= 19 ? "Good afternoon!" : "Good evening!"));
            await context.Response.WriteAsync("<h1>" + greeting + "</h1>");
        }
    }
}