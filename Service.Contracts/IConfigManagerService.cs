using Microsoft.Extensions.Configuration;

namespace Service.Contracts
{
    public interface IConfigManagerService
    {
        T? GetValue<T>(string key);
        T? GetValue<T>(string key, T? defaultValue);
        IConfigurationSection? GetSection(string key);
    }
}