using Common.Constants;
using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Options = Common.Models.Options;

namespace Service
{
    public class BackupService : IBackupService
    {
        private readonly IConfigManagerService _configManager;
        private readonly IOptions<Options> _options;
        private readonly ILogger<BackupService> _logger;
        private readonly IExceptionHandlerService _exceptionHandlerService;

        public BackupService(IConfigManagerService configManager, IOptions<Options> options, ILogger<BackupService> logger, IExceptionHandlerService exceptionHandlerService)
        {
            _configManager = configManager;
            _options = options;
            _logger = logger;
            _exceptionHandlerService = exceptionHandlerService;
        }

        public void Run()
        {
            _logger.LogInformation("Running Backup Service...");

            var paths = _options.Value.Paths;

            if (paths == null || paths.Count == 0)
            {
                _logger.LogInformation("No files to backup. Exiting process...");
                return;
            }

            // creates the path arg string for 7z cmd
            var pathArgs = string.Join(' ', paths);
        }
    }
}