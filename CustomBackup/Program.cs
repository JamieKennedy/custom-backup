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
    builder.BuildConfig();

    var config = builder.Build();

    // Configure the logger
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(config)
        .Enrich.FromLogContext()
        .CreateLogger();

    Log.Information("Starting Application...");

    // Create the host
    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Add services
            services.AddTransient<IBackupService, BackupService>();
        })
        .UseSerilog()
        .Build();

    return host;
}