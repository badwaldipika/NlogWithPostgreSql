using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace Logger
{
    public static class CustomStartup
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            services.AddTransient<ILogger, Logger>();
            services.AddLogging(loggingBuilder => loggingBuilder.AddNLog());
            return services;
        }

    }
}