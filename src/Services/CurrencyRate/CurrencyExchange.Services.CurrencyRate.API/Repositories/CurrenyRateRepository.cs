using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CurrencyExchange.Services.CurrencyRate.API.Repositories
{

    public sealed class CurrenyRateRepository : ICurrenyRateRepository
    {
        const string cacheKey = "symbols";
        static TimeSpan cacheDuration = new TimeSpan(0, 30, 0);
        const string apikey = "9lhhKRceTc8aJpkODvvPl5ylKb2rf8HR";

        readonly ICacheRepository CacheRepository;

        public CurrenyRateRepository(ICacheRepository cacheRepository)
        {
            this.CacheRepository = cacheRepository;
        }

        public async Task<List<CurrencyExchangeRatesEntity>> Get()
        {
            var cacheValue = await this.CacheRepository.GetValueAsync<List<CurrencyExchangeRatesEntity>>(cacheKey);

            if (cacheValue == null)
            {
                var response = await GetCurrencyExchangeRates();

                var currencyExchangeRatesEntity = JsonSerializer.Deserialize<List<CurrencyExchangeRatesEntity>>(response);

                await this.CacheRepository.SetValueAsync(cacheKey, currencyExchangeRatesEntity, cacheDuration);
            }

            return cacheValue;
        }

        public async Task<string> GetCurrencyExchangeRates()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.apilayer.com/fixer/latest");
                client.DefaultRequestHeaders.Add("apikey", apikey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await client.GetStringAsync("");
            }
        }
    }
}
