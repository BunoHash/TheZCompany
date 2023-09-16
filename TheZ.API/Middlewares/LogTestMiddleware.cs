using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace TheZ.API.Middlewares
{

    public class LogTestMiddleware
    {
        private readonly RequestDelegate _next;

        public LogTestMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("usewhen method before the next delegate");
            await _next(context);
            Console.WriteLine("usewhen method after the next delegate");
        }

    }


    public  static class LogTestMiddlewareExtension
    {
        public static IApplicationBuilder UseLogTestMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseWhen(context => context.Request.Query.ContainsKey("log"), (Action<IApplicationBuilder>)(b => {
                UseMiddlewareExtensions.UseMiddleware<LogTestMiddleware>(b);
            }));
            return appBuilder;
        }

    }
}
