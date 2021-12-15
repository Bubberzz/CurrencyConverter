using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Enums;
using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IConversionRepository _repository;
        
        public ConversionService(IConversionRepository repository)
        {
            _repository = repository;
        }

        public async Task<decimal> Convert(Currencies currencyFrom, Currencies currencyTo, int amount)
        {
            var exchangeRates = await _repository.GetExchangeRatesAsync();

            var exchangeRate =
                from rate in exchangeRates
                where rate.Base == currencyFrom
                select rate.Rates;

            decimal result = 0;
            
            foreach (var obj in exchangeRate.Select(rate =>
                rate.GetType().GetProperty(currencyTo.ToString())?.GetValue(rate, null)))
            {
                if (obj == null) continue;
                result = (decimal) obj;
            }

            return result * amount;
        }
    }
}