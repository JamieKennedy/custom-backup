using Common.Constants;
using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class BackupService : IBackupService
    {
        private readonly IConfigManagerService _configManager;
        private readonly ILogger<BackupService> _logger;
        private readonly IExceptionHandlerService _exceptionHandlerService;

        public BackupService(IConfigManagerService configManager, ILogger<BackupService> logger, IExceptionHandlerService exceptionHandlerService)
        {
            _configManager = configManager;
            _logger = logger;
            _exceptionHandlerService = exceptionHandlerService;
        }

        public void Run()
        {
            _logger.LogInformation("Running Backup Service...");

            if (_configManager.GetSection(ConfigurationConst.BACKUP_OPTIONS) == null)
            {
                // Config section is empty
                _exceptionHandlerService.HandleException(new ConfigurationException("No backup options configured. Exiting process", true));
                return;
            }

            var paths = _configManager.GetValue<List<string>>(ConfigurationConst.PATHS);

            if (paths == null || paths.Count == 0)
            {
                _logger.LogInformation("No files to backup. Exiting process");
                return;
            }

            // creates the path arg string for 7z cmd
            var pathArgs = string.Join(' ', paths);



        }
    }
}