using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyConverter.Controllers;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Services;
using CurrencyConverter.Tests.SetupHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class ConvertControllerShould
    {
        private readonly IConversionService _conversionService;
        private readonly ICurrencyService _currencyService;
        private readonly Mock<IConversionRepository> _mockRepository;

        public ConvertControllerShould()
        {
            _mockRepository = new Mock<IConversionRepository>();
            _conversionService = new ConversionService(_mockRepository.Object);
            _currencyService = new CurrencyService();
        }
        [Fact]
        public async Task ConvertControllerShould_ReturnCurrencies_WhenGetCurrenciesIsCalled()
        {
            // Arrange
            var controller = new ConvertController(_conversionService, _currencyService);
            
            // Act
            var result = await controller.GetCurrencies();

            // Assert
            if (result.Result is OkObjectResult resultObject) Assert.Equal(_currencyService.GetCurrenciesToList(), resultObject.Value);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<List<string>>>(result);
        }
        
        [Theory]
        [InlineData("EUR", "USD", 1)]
        public async Task ConvertControllerShould_ConvertCurrencies_WhenGetConversionAsyncIsCalled(string currencyFrom, string currencyTo, int amount)
        {
            // Arrange
            _mockRepository.Setup(x => x.GetExchangeRatesAsync()).ReturnsAsync(GenerateData.GetExchangeRates());
            var controller = new ConvertController(_conversionService, _currencyService);
            
            // Act
            var result = await controller.GetConversionAsync(currencyFrom, currencyTo, amount);

            // Assert
            if (result.Result is OkObjectResult resultObject) Assert.Equal(1.1330124M, resultObject.Value);
            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<decimal>>(result);
            _mockRepository.Verify(mock => mock.GetExchangeRatesAsync(), Times.Once);
        }
    }
}