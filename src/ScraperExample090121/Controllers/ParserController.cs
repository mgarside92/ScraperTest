using Microsoft.AspNetCore.Mvc;
using ScraperExample090121.Domain.Interfaces;
using ScraperExample090121.Models;
using ScraperExample090121.Repositories.ClientWrapper.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScraperExample090121.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        private readonly ISearchEngineURLProvider _searchEngineURLProvider;
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ParserController(ISearchEngineURLProvider searchEngineURLProvider, IHttpClientWrapper httpClientWrapper)
        {
            _searchEngineURLProvider = searchEngineURLProvider;
            _httpClientWrapper = httpClientWrapper;
        }

        // GET: api/Parser
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string terms, [FromQuery] string searchEngine)
        {
            try
            {
                var searchEngineURL = _searchEngineURLProvider.Provide(terms, searchEngine);
                var response = await _httpClientWrapper.GetStringAsync(searchEngineURL);
                return Ok(new SearchEngineResponse { WasSuccessful = true, SearchEngineHTML = response });
            }
            catch
            {
                return BadRequest(new SearchEngineResponse { WasSuccessful = false, SearchEngineHTML = string.Empty });
            }
        }
    }
}