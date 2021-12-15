using CurrencyConverter.Enums;

namespace CurrencyConverter.Entities
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }
        public Currencies Base { get; set; }
        public Rate Rates { get; set; }
    }

 
}