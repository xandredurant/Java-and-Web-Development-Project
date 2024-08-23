using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Java_and_Web_Development_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RssFeedController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RssFeedController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeed(string feedUrl)
        {
            var response = await _httpClient.GetStringAsync(feedUrl);
            return Ok(response);
        }
    }
}
