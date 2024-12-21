using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GeminiController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AIController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Message))
            {
                return BadRequest(new { Error = "Message cannot be null or empty." });
            }

            var apiKey = _configuration["GoogleApi:ApiKey"];
            var apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

            var payload = new
            {
                model = "gemini-1.5-flash",
                prompt = request.Message,
                max_tokens = 100
            };

            try
            {
                var client = _httpClientFactory.CreateClient();
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}?key={apiKey}")
                {
                    Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<MessageResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, new { Error = responseContent });
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { Error = $"HTTP Request failed: {ex.Message}" });
            }
        }
    }

    public class MessageRequest
    {
        public string Message { get; set; }
    }

    public class MessageResponse
    {
        public string Text { get; set; }
    }
}
