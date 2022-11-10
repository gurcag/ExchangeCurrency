using System;
namespace CurrencyExchange.Services.CurrencyRate.API.Entities
{
    public class CurrencyRateEntity : BaseEntity
    {
        public SymbolEntity Symbol { get; set; }
        public decimal Value { get; set; }
    }
}