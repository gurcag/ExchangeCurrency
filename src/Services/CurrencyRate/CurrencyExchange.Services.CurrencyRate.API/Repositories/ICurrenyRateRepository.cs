using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;

namespace CurrencyExchange.Services.CurrencyRate.API.Repositories
{
    public interface ICurrenyRateRepository
    {
        Task<List<CurrencyExchangeRatesEntity>> Get();
    }
}

