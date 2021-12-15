using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyConverter.Enums;
using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Services
{
    public class CurrencyService : ICurrencyService
    {
        public List<string> GetCurrenciesToList()
        {
            return Enum.GetNames(typeof(Currencies)).ToList();
        }
    }
}