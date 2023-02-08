using Microsoft.Extensions.Configuration;
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
    }
}