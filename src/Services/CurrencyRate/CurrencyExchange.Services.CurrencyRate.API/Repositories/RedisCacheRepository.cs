using System;
using StackExchange.Redis;
using System.Text.Json;

namespace CurrencyExchange.Services.CurrencyRate.API.Repositories
{
    public class RedisCacheRepository : ICacheRepository
    {
        readonly IConnectionMultiplexer connectionMultiplexer;
        readonly IDatabase database;

        public RedisCacheRepository(IConnectionMultiplexer redisCon)
        {
            connectionMultiplexer = redisCon;
            database = redisCon.GetDatabase();
        }

        public async Task Clear(string key)
        {
            await database.KeyDeleteAsync(key);
        }

        public void ClearAll()
        {
            var endpoints = connectionMultiplexer.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }

        public async Task<T> GetValueAsync<T>(string key)
        {
            var result = await database.StringGetAsync(key);

            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task<bool> SetValueAsync<T>(string key, T value, TimeSpan interval)
        {
            var serValue = JsonSerializer.SerializeToUtf8Bytes(value);
            return await database.StringSetAsync(key, serValue, interval);
        }
    }
}