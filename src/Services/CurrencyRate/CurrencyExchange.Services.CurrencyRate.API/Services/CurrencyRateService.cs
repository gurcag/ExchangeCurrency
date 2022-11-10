using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;
using CurrencyExchange.Services.CurrencyRate.API.Repositories;

namespace CurrencyExchange.Services.CurrencyRate.API.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        readonly ICurrenyRateRepository CurrenyRateRepository;

        public CurrencyRateService(ICurrenyRateRepository currenyRateRepository)
        {
            this.CurrenyRateRepository = currenyRateRepository;
        }

        public async Task<List<CurrencyExchangeRatesEntity>> Get()
        {
            return await this.CurrenyRateRepository.Get();
        }
    }
}

