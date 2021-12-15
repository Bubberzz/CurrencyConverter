using System.Collections.Generic;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Services;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class CurrencyServiceShould
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyServiceShould()
        {
            _currencyService = new CurrencyService();
        }
        [Fact]
        public void CurrencyServiceShould_ReturnCurrencyList_WhenGetCurrenciesToListIsCalled()
        {
            // Act
            var result = _currencyService.GetCurrenciesToList();

            // Assert
            Assert.IsType<List<string>>(result);
            Assert.Equal(5, result.Count);
        }
    }
}