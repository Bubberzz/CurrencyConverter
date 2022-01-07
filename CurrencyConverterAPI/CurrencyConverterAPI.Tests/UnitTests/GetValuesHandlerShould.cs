using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.CQRS.Handlers;
using CurrencyConverter.CQRS.Queries;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Tests.SetupHelper;
using Moq;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class GetValuesHandlerShould
    {
        private readonly Mock<IConversionRepository> _mockRepository;
        private readonly GetValuesHandler _valuesHandler;


        public GetValuesHandlerShould()
        {
            _mockRepository = new Mock<IConversionRepository>();
            _valuesHandler = new GetValuesHandler(_mockRepository.Object);
        }
        
        [Theory]
        [InlineData("EUR", "USD", 1)]
        public async Task GetValuesHandlerShould_ReturnCorrectAmount_WhenHandlerIsCalled(string currencyFrom, string currencyTo, int amount)
        {
            // Arrange
            _mockRepository.Setup(x => x.GetExchangeRatesAsync()).ReturnsAsync(GenerateData.GetExchangeRates());

            // Act
            var result =
                await _valuesHandler.Handle(new GetValuesQuery.GetExchangeRateAsync(currencyFrom, currencyTo, amount), CancellationToken.None);

            // Assert
            Assert.Equal(1.1330124M, result);
            _mockRepository.Verify(mock => mock.GetExchangeRatesAsync(), Times.Once);
        }
        
        [Fact]
        public async Task GetValuesHandlerShould_ReturnCurrencies_WhenHandlerIsCalled()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetExchangeRatesAsync()).ReturnsAsync(GenerateData.GetExchangeRates());

            // Act
            var result =
                await _valuesHandler.Handle(new GetValuesQuery.GetCurrenciesAsync(), CancellationToken.None);

            // Assert
            Assert.IsType<List<string>>(result);
            Assert.Single(result);
            _mockRepository.Verify(mock => mock.GetExchangeRatesAsync(), Times.Once);
        }
    }
}