using CurrencyConverter.Entities;
using MediatR;

namespace CurrencyConverter.CQRS.Commands
{
    public class AddValuesCommand
    {
        public record AddExchangeRateCommand(ExchangeRate ExchangeRate) : IRequest;
    }
}