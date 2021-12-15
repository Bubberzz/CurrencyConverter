using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Entities;
using CurrencyConverter.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        [Route("/convert")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetConversionAsync(string currencyFrom, string currencyTo, int amount)
        {
            var exchangeRates = new ExchangeRate()
            {
                ExchangeRateId = 1
            };
            return Ok(exchangeRates);
        }
        
        [Route("/getcurrencies")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetCurrenciesAsync()
        {
            return Ok(new Currencies());
        }
    }
}
