using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pati.Infrastructure
{
    public interface ICacheService
    {
        void SetString(string key, string value, TimeSpan? expiration = null);

        string GetString(string key);

        void SetValue<T>(string key, T value, TimeSpan? expiration = null);

        T GetValue<T>(string key);

        List<T> GetValues<T>(string[] keys);

        Task SetStringAsync(string key, string value, TimeSpan? expiration = null);
        
        Task<string> GetStringAsync(string key);

        Task SetValueAsync<T>(string key, T value, TimeSpan? expiration = null);

        Task<T> GetValueAsync<T>(string key);

        Task<List<T>> GetValuesAsync<T>(string[] keys);
    }
}
