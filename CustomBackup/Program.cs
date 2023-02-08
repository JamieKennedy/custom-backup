using CustomBackup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = Startup();

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

    // Create the host
    var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) => { })
        .UseSerilog()
        .Build();

    return host;
}