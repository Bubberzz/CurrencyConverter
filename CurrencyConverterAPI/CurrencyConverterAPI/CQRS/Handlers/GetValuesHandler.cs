using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.CQRS.Queries;
using CurrencyConverter.Interfaces;
using MediatR;

namespace CurrencyConverter.CQRS.Handlers
{
    public class GetValuesHandler : 
        IRequestHandler<GetValuesQuery.GetCurrenciesAsync, List<string>>, 
        IRequestHandler<GetValuesQuery.GetExchangeRateAsync, decimal>
    {
        private readonly IConversionRepository _repository;

        public GetValuesHandler(IConversionRepository repository) => _repository = repository;

        public async Task<List<string>> Handle(GetValuesQuery.GetCurrenciesAsync request, CancellationToken cancellationToken)
        {
            var exchangeRates = await _repository.GetExchangeRatesAsync();
            
            return exchangeRates.Select(rate => rate.BaseCurrency.ToString()).ToList();
        }

        public async Task<decimal> Handle(GetValuesQuery.GetExchangeRateAsync request, CancellationToken cancellationToken)
        {
            var exchangeRates = await _repository.GetExchangeRatesAsync();

            var exchangeRate =
                from rate in exchangeRates
                where rate.BaseCurrency == request.CurrencyFrom
                select rate.Rates;

            decimal result = 0;
            
            foreach (var obj in exchangeRate.Select(rate =>
                         rate.GetType().GetProperty(request.CurrencyTo.ToString())?.GetValue(rate, null)))
            {
                if (obj == null) continue;
                result = (decimal) obj;
            }

            return result * request.Amount;
        }
    }
}