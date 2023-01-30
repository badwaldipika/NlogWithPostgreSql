using Microsoft.AspNetCore.Builder;

namespace ErrorHandler
{
    public static class CustomStartup
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}