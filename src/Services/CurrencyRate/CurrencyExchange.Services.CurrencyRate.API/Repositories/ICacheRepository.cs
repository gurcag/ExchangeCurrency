using System;
namespace CurrencyExchange.Services.CurrencyRate.API.Repositories
{
    public interface ICacheRepository
    {
        Task<T> GetValueAsync<T>(string key);
        Task<bool> SetValueAsync<T>(string key, T value, TimeSpan interval);
        Task Clear(string key);
        void ClearAll();
    }
}

