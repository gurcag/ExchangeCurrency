using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;

namespace CurrencyExchange.Services.CurrencyRate.API.Services
{
    public interface ICurrencyRateService
    {
        Task<List<CurrencyExchangeRatesEntity>> Get();
    }
}

