using System.Collections.Generic;

namespace CurrencyConverter.Interfaces
{
    public interface ICurrencyService
    {
        List<string> GetCurrenciesToList();
    }
}