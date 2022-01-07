using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Context;
using CurrencyConverter.Entities;
using CurrencyConverter.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Repository
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly ExchangeRateDbContext _context;

        public ConversionRepository(ExchangeRateDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesAsync()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        public async Task AddExchangeRatesAsync(ExchangeRate exchangeRate)
        {
            await _context.ExchangeRates.AddAsync(exchangeRate);
            await _context.SaveChangesAsync();
        }
    }
}