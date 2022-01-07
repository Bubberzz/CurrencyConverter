using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Entities;

namespace CurrencyConverter.Interfaces
{
    public interface IConversionRepository
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync();
        Task AddExchangeRatesAsync(ExchangeRate exchangeRate);
    }
}