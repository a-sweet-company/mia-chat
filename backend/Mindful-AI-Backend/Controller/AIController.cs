using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
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
            var clientSecrets = new ClientSecrets
            {
                ClientId = "653772676254-mli7gua85a4kfffmc3a12evrgit90hjn.apps.googleusercontent.com",
                ClientSecret = "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"
            };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[] { "https://www.googleapis.com/oauth2/v1/certs" },
                "user",
                CancellationToken.None,
                new FileDataStore("TokenStore"));

            var apiUrl = "https://api.gemini.com/v1/completions"; // Endpoint correto
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
