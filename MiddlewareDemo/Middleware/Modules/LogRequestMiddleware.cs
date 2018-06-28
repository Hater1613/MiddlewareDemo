using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo.Middleware.Modules
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _fileName;

        public LogRequestMiddleware(RequestDelegate next, string fileName)
        {
            _next = next;
            _fileName = fileName;
        }

        public async Task Invoke(HttpContext context)
        {
            var message = new StringBuilder();
            message.Append($"Protocol: { context.Request.Protocol } ");
            message.Append($"Host: { context.Request.Host } ");
            message.Append($"Method: { context.Request.Method } ");
            try
            {
                using (var streamWriter = new StreamWriter(_fileName, true, Encoding.Default))
                {
                    streamWriter.WriteLine(message);
                }

                await _next.Invoke(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}