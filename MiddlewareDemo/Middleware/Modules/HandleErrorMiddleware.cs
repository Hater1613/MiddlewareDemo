using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware.Modules
{
    public class HandleErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            var statusCode = context.Response.StatusCode;
            if (statusCode == 403)
            {
                await context.Response.WriteAsync("<h1>Access denied!</h1>");
            }

            if (statusCode == 404)
            {
                await context.Response.WriteAsync("<h1>Not found!</h1>");
            }

            if (statusCode == 500)
            {
                await context.Response.WriteAsync("<h1>Something went wrong!</h1>");
            }
        }
    }
}