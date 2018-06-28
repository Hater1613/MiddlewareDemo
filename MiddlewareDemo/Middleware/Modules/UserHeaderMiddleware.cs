using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middleware.Modules
{
    public class UserHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public UserHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("X-UserName",
                context.User.Identity.IsAuthenticated ? new[] { context.User.Identity.Name } : new[] { "Guest" });
            await _next.Invoke(context);
        }
    }
}