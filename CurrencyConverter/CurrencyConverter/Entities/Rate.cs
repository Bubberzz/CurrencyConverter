namespace CurrencyConverter.Entities
{
    public abstract class Rate
    {
        public int ExchangeRateId { get; set; }
        public decimal USD { get; set; }
        public decimal EUR { get; set; }
        public decimal GBP { get; set; }
        public decimal CAD { get; set; }
        public decimal AUD { get; set; }
        

    }
}