using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class BackupService : IBackupService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<BackupService> _logger;

        public BackupService(IConfiguration config, ILogger<BackupService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Running Backup Service...");
        }
    }
}