using NUnit.Framework;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;

namespace crypto_restapi.UnitTests
{
    public class ExchangeRates
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            // Initialize HttpClient with the base URL of your API
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        [Test]
        public async Task GetEndpoint_ReturnsSuccessStatusCode()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "exchangeRates");

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task PostEndpoint_ReturnsCreatedStatusCode()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, "exchangeRates");
            // Set request content if needed

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task PutEndpoint_ReturnsNoContentStatusCode()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, "exchangeRates");
            // Set request content if needed

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public async Task DeleteEndpoint_ReturnsNotFoundStatusCode()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete, "exchangeRates");

            // Act
            var response = await _httpClient.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        // Add more tests for your specific endpoints as needed
    }
}
