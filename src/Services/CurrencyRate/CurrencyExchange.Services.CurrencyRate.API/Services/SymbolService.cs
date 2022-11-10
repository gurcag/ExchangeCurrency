using System;
using CurrencyExchange.Services.CurrencyRate.API.Entities;
using CurrencyExchange.Services.CurrencyRate.API.Repositories;

namespace CurrencyExchange.Services.CurrencyRate.API.Services
{
    public class SymbolService : ISymbolService
    {
        readonly ISymbolRepository SymbolRepository;

        public SymbolService(ISymbolRepository symbolRepository)
        {
            this.SymbolRepository = symbolRepository;
        }

        public async Task<List<SymbolEntity>> Get()
        {
            return await this.SymbolRepository.Get();
        }
    }
}