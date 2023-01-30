using Microsoft.Extensions.Logging;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly ILogger<Logger> _logger;

        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }

        public async Task LogError(string error)
        {
            await Task.Run(() => _logger.LogError(error));
        }

        public async Task LogInformation(string information)
        {
            await Task.Run(() => _logger.LogInformation(information));
        }

        public async Task LogTrace(string message)
        {
            await Task.Run(() => _logger.LogTrace(message));
        }
    }
}
