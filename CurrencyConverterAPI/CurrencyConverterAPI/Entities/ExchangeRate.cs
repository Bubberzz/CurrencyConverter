namespace CurrencyConverter.Entities
{
    public record ExchangeRate
    {
        public int ExchangeRateId { get; set; }
        public string BaseCurrency { get; set; }
        public Rate Rates { get; set; }
    }

 
}