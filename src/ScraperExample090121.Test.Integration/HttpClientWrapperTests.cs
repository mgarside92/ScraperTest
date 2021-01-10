using NUnit.Framework;
using ScraperExample090121.Repositories.ClientWrapper;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScraperExample090121.Test.Integration
{
    [TestFixture]
    public class HttpClientWrapperTests
    {
        private HttpClientWrapper _httpClientWrapper;

        [SetUp]
        public void Setup()
        {
            var httpClient = new HttpClient();
            _httpClientWrapper = new HttpClientWrapper(httpClient);
        }

        [Test]
        public async Task GetStringAsync_Should_Return_String()
        {
            //Arrange
            var url = "https://www.google.com";

            //Act
            var response = await _httpClientWrapper.GetStringAsync(url);

            //Assert
            Assert.IsNotEmpty(response);
        }
    }
}
