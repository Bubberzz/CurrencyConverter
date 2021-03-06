using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
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
            var result = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);

            // Assert
            response.EnsureSuccessStatusCode();
            if (response.Content.Headers.ContentType != null)
                Assert.Equal("application/json; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
            Assert.Contains("USD", result.ToString() ?? string.Empty);
            Assert.Contains("EUR", result.ToString() ?? string.Empty);
            Assert.Contains("GBP", result.ToString() ?? string.Empty);
            Assert.Contains("AUD", result.ToString() ?? string.Empty);
            Assert.Contains("CAD", result.ToString() ?? string.Empty);

        }
    }
}