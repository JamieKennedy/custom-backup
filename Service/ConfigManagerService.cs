using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class ConfigManagerService : IConfigManagerService
    {
        private readonly ILogger<ConfigManagerService> _logger;
        private readonly IConfiguration _config;


        public ConfigManagerService(ILogger<ConfigManagerService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }


        public T? GetValue<T>(string key)
        {
            var val = _config.GetSection(key);

            return val.Exists() ? val.Get<T>() : default;
        }

        public T? GetValue<T>(string key, T? defaultValue)
        {
            return _config[key] == null ? defaultValue : GetValue<T>(key);
        }

        /// <summary>
        /// Attempts to get the section with the corresponding key
        /// If section does not exist, returns null
        /// </summary>
        /// <param name="key">Key for the appsettings section</param>
        /// <returns></returns>
        /// <exception></exception>
        public IConfigurationSection? GetSection(string key)
        {
            var section = _config.GetSection(key);

            return section.Exists() ? section : null;
        }
    }
}