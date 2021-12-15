using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Enums;
using CurrencyConverter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IConversionService _conversionService;
        private readonly ICurrencyService _currencyService;

        public ConvertController(IConversionService conversionService, ICurrencyService currencyService)
        {
            _conversionService = conversionService;
            _currencyService = currencyService;
        }

        [Route("/convert")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetConversionAsync(string currencyFrom, string currencyTo, int amount)
        {
            if (!(Enum.TryParse(currencyFrom, out Currencies from) & Enum.TryParse(currencyTo, out Currencies to)))
                return StatusCode(500);
            var exchangeRates = await _conversionService.Convert(@from, to, amount).ConfigureAwait(false);
            return Ok(exchangeRates);
        }
        
        [Route("/getcurrencies")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetCurrenciesAsync()
        {
            return Ok(await Task.Run(() => _currencyService.GetCurrenciesToList()).ConfigureAwait(false));
        }
    }
}
