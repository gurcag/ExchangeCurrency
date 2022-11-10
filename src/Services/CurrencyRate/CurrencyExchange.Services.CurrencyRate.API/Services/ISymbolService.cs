using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;

namespace CurrencyExchange.Services.CurrencyRate.API.Services
{
    public interface ISymbolService
    {
        Task<List<SymbolEntity>> Get();
    }
}