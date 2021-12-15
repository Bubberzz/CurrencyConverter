using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CurrencyConverter.Tests.IntegrationTests
{
    public class GetCurrenciesEndpointShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GetCurrenciesEndpointShould(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/getcurrencies")]
        public async Task GetCurrenciesEndpointShould_ReturnSuccess_AndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            if (response.Content.Headers.ContentType != null)
                Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
        }
    }
}