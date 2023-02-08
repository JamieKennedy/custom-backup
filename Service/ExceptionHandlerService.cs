using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class ExceptionHandlerService : IExceptionHandlerService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ExceptionHandlerService> _logger;

        public ExceptionHandlerService(IConfiguration config, ILogger<ExceptionHandlerService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public void HandleException(Exception ex)
        {
            switch (ex)
            {
                case ConfigurationException cex:
                    _logger.LogError(cex.Message);
                    if (cex.Fatal)
                    {
                        Environment.Exit((int)ConfigurationException.ExitCode);
                    }
                    break;
            }
        }
    }
}