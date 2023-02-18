using Common.Models;
using CustomBackup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Service;
using Service.Contracts;

var host = Startup();

// Create backup service instance
var backupService = ActivatorUtilities.CreateInstance<BackupService>(host.Services);

// Run the backup service
backupService.Run();

static IHost Startup()
{
    var builder = new ConfigurationBuilder();
    // Adds configuration from appsettings
    builder.BuildConfig();

    // pre build to have access to appsettings configuration
    // when building options
    var config = builder.Build();

    // Configure the logger
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config)
        .Enrich.FromLogContext()
        .CreateLogger();

    Log.Information("Starting Application...");

    // Adds backup options json file
    builder.BuildOptions(config, Log.Logger);
    config = builder.Build();

    // Create the host
    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            // Add services
            services.AddTransient<IExceptionHandlerService, ExceptionHandlerService>();
            services.AddTransient<IConfigManagerService, ConfigManagerService>();
            services.AddTransient<IBackupService, BackupService>();
            services.AddOptions<Options>().Bind(config.GetSection(Options.OPTIONS_SECTION_NAME));
        })
        .UseSerilog()
        .Build();

    return host;
}