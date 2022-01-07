using System.Collections.Generic;
using MediatR;

namespace CurrencyConverter.CQRS.Queries
{
    public class GetValuesQuery
    {
        public record GetExchangeRateAsync(string CurrencyFrom, string CurrencyTo, int Amount) : IRequest<decimal>;
        public record GetCurrenciesAsync() : IRequest<List<string>>;
    }
}