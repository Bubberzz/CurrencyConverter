using System.Collections.Generic;
using CurrencyConverter.Entities;
using CurrencyConverter.Enums;

namespace CurrencyConverter.Tests.SetupHelper
{
    public static class GenerateData
    {
        internal static IEnumerable<ExchangeRate> GetExchangeRates()
        {
            return new List<ExchangeRate>()
            {
                new()
                {
                    ExchangeRateId = 1,
                    Base = Currencies.EUR,
                    Rates = new Rate()
                    {
                        ExchangeRateId = 1,
                        USD = 1.1330124m,
                        EUR = 1.00m,
                        GBP = 0.85211351m,
                        CAD = 1.4486056m,
                        AUD = 1.5903791m
                    }
                }
            };
        }
    }
}