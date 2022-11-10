using System;
namespace CurrencyExchange.Services.CurrencyRate.API.Entities
{
    public class SymbolEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

