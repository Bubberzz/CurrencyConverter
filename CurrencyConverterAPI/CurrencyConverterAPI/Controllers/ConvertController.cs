using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.CQRS.Commands;
using CurrencyConverter.CQRS.Queries;
using CurrencyConverter.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConvertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/convert")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetConversionAsync(string currencyFrom, string currencyTo, int amount)
        {
            return Ok(await _mediator.Send(new GetValuesQuery.GetExchangeRateAsync(currencyFrom, currencyTo, amount))
                .ConfigureAwait(false));
        }

        [Route("/getcurrencies")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetCurrenciesAsync()
        {
            return Ok(await _mediator.Send(new GetValuesQuery.GetCurrenciesAsync()).ConfigureAwait(false));
        }

        [Route("/add")]
        [HttpPost]
        public async Task<ActionResult> AddExchangeRate([FromBody] ExchangeRate exchangeRate)
        {
            {
                await _mediator.Send(new AddValuesCommand.AddExchangeRateCommand(exchangeRate));
                return StatusCode(201);
            }
        }
    }
}
