using System.Threading.Tasks;
using CurrencyConverter.Enums;

namespace CurrencyConverter.Interfaces
{
    public interface IConversionService
    {
        Task<decimal>  Convert(Currencies currencyFrom, Currencies currencyTo, int amount);
    }
}