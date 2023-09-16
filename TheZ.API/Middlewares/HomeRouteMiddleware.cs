using System.Diagnostics;

namespace TheZ.API.Middlewares
{
    public class HomeRouteMiddleware
    {
        private readonly RequestDelegate _next;

        public HomeRouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Debug.WriteLine($" ======== Response handled by {nameof(HomeRouteMiddleware)} ======== ");
            await _next.Invoke(context);
        }
    }

    public static class HomeRouteMiddlewareExtensions
    {
        public static IApplicationBuilder UseHomePathMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.Map("/home", b => {
                b.UseMiddleware<HomeRouteMiddleware>();
            });
            return appBuilder;
        }

    }
}
