using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CurrencyExchange.Services.CurrencyRate.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyExchange.Services.CurrencyRate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SymbolsController : Controller
    {
        readonly ISymbolService SymbolService;

        public SymbolsController(ISymbolService symbolService)
        {
            this.SymbolService = symbolService;
        }

        [HttpGet]
        public async Task<IActionResult> Symbols()
        {
            var symbols = await this.SymbolService.Get();
            return Ok(symbols);
        }
    }
}

