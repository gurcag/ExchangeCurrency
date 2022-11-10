using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Services.Exchange.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}

