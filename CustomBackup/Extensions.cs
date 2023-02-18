using Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CustomBackup
{
    public static class Extensions
    {


        public static void BuildConfig(this IConfigurationBuilder builder)
        {
            // If env var can't be found default to prod
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        public static void BuildOptions(this IConfigurationBuilder builder, IConfigurationRoot config, ILogger logger)
        {
            var customPath = config["OptionsPath"];

            // If custom path is specified in appsettings, use that otherwise use the default
            var optionsPath = string.IsNullOrEmpty(customPath) ? Path.Combine(Directory.GetCurrentDirectory(), "options.json") : customPath;

            if (!File.Exists(optionsPath))
            {
                // options file doesn't exist
                logger.Error("No options file found. Exiting process...");
                Environment.Exit((int)ConfigurationException.ExitCode);
            }

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("options.json", optional: false, reloadOnChange: true);
        }
    }
}