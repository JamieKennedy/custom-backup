using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class BackupService : IBackupService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<BackupService> _logger;
        private readonly IExceptionHandlerService _exceptionHandlerService;

        public BackupService(IConfiguration config, ILogger<BackupService> logger, IExceptionHandlerService exceptionHandlerService)
        {
            _config = config;
            _logger = logger;
            _exceptionHandlerService = exceptionHandlerService;
        }

        public void Run()
        {
            _logger.LogInformation("Running Backup Service...");

            var options = _config.GetSection("BackOptions");

            if (!options.Exists())
            {
                // Config section is empty
                _exceptionHandlerService.HandleException(new ConfigurationException("No backup options configured. Exiting process", true));
            }

        }
    }
}