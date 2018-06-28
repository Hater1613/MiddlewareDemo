using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware.Modules
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _pattern;

        public AuthorizeMiddleware(RequestDelegate next, string pattern)
        {
            _next = next;
            _pattern = pattern;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != _pattern)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}