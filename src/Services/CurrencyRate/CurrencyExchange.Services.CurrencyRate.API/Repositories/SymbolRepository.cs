using System;
using System.Net.Http.Headers;
using System.Text.Json;
using CurrencyExchange.Services.CurrencyRate.API.Entities;
using CurrencyExchange.Services.CurrencyRate.API.Services;

namespace CurrencyExchange.Services.CurrencyRate.API.Repositories
{
    public sealed class SymbolRepository : ISymbolRepository
    {
        const string cacheKey = "symbols";
        static TimeSpan cacheDuration = new TimeSpan(24, 0, 0);

        readonly ICacheRepository CacheRepository;

        const string apikey = "9lhhKRceTc8aJpkODvvPl5ylKb2rf8HR";

        public SymbolRepository(ICacheRepository cacheRepository)
        {
            this.CacheRepository = cacheRepository;
        }

        public async Task<List<SymbolEntity>> Get()
        {
            var cacheValue =  await this.CacheRepository.GetValueAsync<List<SymbolEntity>>(cacheKey);

            if (cacheValue == null)
            {
                var response = await GetSymbols();

                var symbols = JsonSerializer.Deserialize<List<SymbolEntity>>(response);

                await this.CacheRepository.SetValueAsync(cacheKey, symbols, cacheDuration);
            }

            return cacheValue;
        }

        async Task<string> GetSymbols()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.apilayer.com/fixer/symbols");
                client.DefaultRequestHeaders.Add("apikey", apikey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.GetStringAsync("");
            }
        }
    }
}