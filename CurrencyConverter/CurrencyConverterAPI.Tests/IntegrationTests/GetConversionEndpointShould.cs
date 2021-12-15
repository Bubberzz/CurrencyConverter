using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CurrencyConverter.Tests.IntegrationTests
{
    public class GetConversionEndpointShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetConversionEndpointShould(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/convert")]
        public async Task GetConversion_EndpointsReturnSuccess_AndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{url}?currencyFrom=USD&currencyTo=EUR&amount=1");

            // Assert
            response.EnsureSuccessStatusCode();
            if (response.Content.Headers.ContentType != null)
                Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
        } 
        
        [Theory]
        [InlineData("/convert")]
        public async Task GetConversion_EndpointsReturnServerError_WhenTheUrlParametersAreIncorrect(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{url}?currencyFrom=USB&currencyTo=ERU&amount=1");

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal("InternalServerError", response.StatusCode.ToString());
        } 
    }
}