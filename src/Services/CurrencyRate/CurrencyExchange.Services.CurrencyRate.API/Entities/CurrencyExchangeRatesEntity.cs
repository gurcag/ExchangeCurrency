using System;
namespace CurrencyExchange.Services.CurrencyRate.API.Entities
{
    public class CurrencyExchangeRatesEntity : BaseEntity
    {
        public SymbolEntity BaseCurrencySymbol { get; set; }
        public List<CurrencyRateEntity> ExchangeCurrencyRates { get; set; }
    }
}