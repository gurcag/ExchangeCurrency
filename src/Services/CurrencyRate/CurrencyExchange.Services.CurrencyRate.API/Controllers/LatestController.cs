using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Services.CurrencyRate.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyExchange.Services.CurrencyRate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LatestController : Controller
    {
        readonly ICurrencyRateService CurrencyRateService;

        public LatestController(ICurrencyRateService  currencyRateService)
        {
            this.CurrencyRateService = currencyRateService;
        }

        [HttpGet]
        public async Task<IActionResult> Latest()
        {
            var currencyExchangeRates = await this.CurrencyRateService.Get();
            return Ok(currencyExchangeRates);
        }
    }
}

