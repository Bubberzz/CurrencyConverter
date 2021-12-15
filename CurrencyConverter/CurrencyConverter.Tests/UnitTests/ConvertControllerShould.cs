using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class ConvertControllerShould
    {
        [Fact]
        public async Task ConvertControllerShould_ReturnCurrencies_WhenGetCurrenciesAsyncIsCalled()
        {
            // Arrange
            var controller = new ConvertController();
            
            // Act
            var result = await GetCurrencies();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<List<string>>>(result);
        }
        
        [Theory]
        [InlineData("EUR", "USD", 1)]
        public async Task ConvertControllerShould_ConvertCurrencies_WhenGetConversionAsyncIsCalled(string currencyFrom, string currencyTo, int amount)
        {
            // Arrange
            var controller = new ConvertController();
            
            // Act
            var result = await controller.GetConversionAsync(currencyFrom, currencyTo, amount);

            // Assert
            if (result.Result is OkObjectResult resultObject) Assert.Equal(1.1330124M, resultObject.Value);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<decimal>>(result);
        }
    }
}