using System.Threading.Tasks;
using CurrencyConverter.Enums;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Services;
using CurrencyConverter.Tests.SetupHelper;
using Moq;
using Xunit;

namespace CurrencyConverter.Tests.UnitTests
{
    public class ConversionServiceShould
    {
        private readonly IConversionService _conversionService;
        private readonly Mock<IConversionRepository> _mockRepository;

        public ConversionServiceShould()
        {
            _mockRepository = new Mock<IConversionRepository>();
            _conversionService = new ConversionService(_mockRepository.Object);
        }
        [Theory]
        [InlineData(Currencies.EUR, Currencies.USD, 1)]
        public async Task ConversionServiceShould_ReturnCorrectAmount_WhenConvertIsCalled(Currencies currencyFrom, Currencies currencyTo, int amount)
        {
            // Arrange
            _mockRepository.Setup(x => x.GetExchangeRatesAsync()).ReturnsAsync(GenerateData.GetExchangeRates());

            // Act
            var result = await _conversionService.Convert(currencyFrom, currencyTo, amount);

            // Assert
            Assert.Equal(1.1330124M, result);
            _mockRepository.Verify(mock => mock.GetExchangeRatesAsync(), Times.Once);
        }
    }
}