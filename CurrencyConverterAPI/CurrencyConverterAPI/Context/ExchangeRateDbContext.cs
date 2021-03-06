using CurrencyConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Context
{
    public class ExchangeRateDbContext : DbContext
    {
        public DbSet<ExchangeRate> ExchangeRates { get; set; }


        public ExchangeRateDbContext(DbContextOptions<ExchangeRateDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate()
                {
                    ExchangeRateId = 1,
                    BaseCurrency = "EUR",
                });
            
            modelBuilder.Entity<ExchangeRate>().OwnsOne(x => x.Rates).HasData(
                new Rate()
                {
                    ExchangeRateId = 1,
                    USD = 1.1330124m,
                    EUR = 1.00m,
                    GBP = 0.85211351m,
                    CAD = 1.4486056m,
                    AUD = 1.5903791m
                });

            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate()
                {
                    ExchangeRateId = 2,
                    BaseCurrency = "USD"
                });
            
            modelBuilder.Entity<ExchangeRate>().OwnsOne(x => x.Rates).HasData(
                new Rate()
                {
                    ExchangeRateId = 2,
                    USD = 1.00m,
                    EUR = 0.88256944m,
                    GBP = 0.75202136m,
                    CAD = 1.2782366m,
                    AUD = 1.4029602m
                });
            
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate()
                {
                    ExchangeRateId = 3,
                    BaseCurrency = "GBP"
                });
            
            modelBuilder.Entity<ExchangeRate>().OwnsOne(x => x.Rates).HasData(
                new Rate()
                {
                    ExchangeRateId = 3,
                    USD = 1.329946m,
                    EUR = 1.1736505m,
                    GBP = 1.00m,
                    CAD = 1.6996745m,
                    AUD = 1.8661064m
                });
            
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate()
                {
                    ExchangeRateId = 4,
                    BaseCurrency = "CAD"
                });
            
            modelBuilder.Entity<ExchangeRate>().OwnsOne(x => x.Rates).HasData(
                new Rate()
                {
                    ExchangeRateId = 4,
                    USD = 0.7825025m,
                    EUR = 0.6905492m,
                    GBP = 0.58834283m,
                    CAD = 1.00m,
                    AUD = 1.0979199m
                });
            
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate()
                {
                    ExchangeRateId = 5,
                    BaseCurrency = "AUD"
                });
            
            modelBuilder.Entity<ExchangeRate>().OwnsOne(x => x.Rates).HasData(
                new Rate()
                {
                    ExchangeRateId = 5,
                    USD = 0.71271908m,
                    EUR = 0.62898345m,
                    GBP = 0.53585038m,
                    CAD = 0.9108951m,
                    AUD = 1.00m
                });
        }
    }
}