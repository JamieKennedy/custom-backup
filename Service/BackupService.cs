using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class BackupService
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

        }
    }
}