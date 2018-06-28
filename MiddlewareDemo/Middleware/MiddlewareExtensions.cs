using Microsoft.AspNetCore.Builder;
using MiddlewareDemo.Middleware.Modules;

namespace MiddlewareDemo.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleError(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleErrorMiddleware>();
        }

        public static IApplicationBuilder UseUserHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserHeaderMiddleware>();
        }

        public static IApplicationBuilder UseLogRequest(this IApplicationBuilder builder, string fileName)
        {
            return builder.UseMiddleware<LogRequestMiddleware>(fileName);
        }

        public static IApplicationBuilder UseAuthorize(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<AuthorizeMiddleware>(pattern);
        }

        public static IApplicationBuilder UseTimesOfDay(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimesOfDayMiddleware>();
        }
    }
}