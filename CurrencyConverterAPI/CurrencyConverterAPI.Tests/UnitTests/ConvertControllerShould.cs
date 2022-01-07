using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class ConvertControllerShould
    {
        private readonly Mock<IMediator> _mediator;

        public ConvertControllerShould()
        {
            _mediator = new Mock<IMediator>();

        }
        
        [Fact]
        public async Task ConvertControllerShould_ReturnCurrencies_WhenGetCurrenciesAsyncIsCalled()
        {
            // Arrange
            var controller = new ConvertController(_mediator.Object);
            
            // Act
            var result = await controller.GetCurrenciesAsync();

            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<List<string>>>(result);
        }
        
        [Theory]
        [InlineData("EUR", "USD", 1)]
        public async Task ConvertControllerShould_ConvertCurrencies_WhenGetConversionAsyncIsCalled(string currencyFrom, string currencyTo, int amount)
        {
            // Arrange
            var controller = new ConvertController(_mediator.Object);
            
            // Act
            var result = await controller.GetConversionAsync(currencyFrom, currencyTo, amount);
        
            // Assert
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<decimal>>(result);
        }
    }
}