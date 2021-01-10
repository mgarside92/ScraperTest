using ScraperExample090121.Repositories.ClientWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScraperExample090121.Repositories.ClientWrapper
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStringAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Request failed, error: {response.ReasonPhrase}");

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}
