using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
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
            if (string.IsNullOrWhiteSpace(request?.Message))
            {
                return BadRequest(new { Error = "Message cannot be null or empty." });
            }

            // Obter credenciais do appsettings.json
            var clientId = _configuration["GoogleApi:ClientId"];
            var clientSecret = _configuration["GoogleApi:ClientSecret"];
            var apiKey = _configuration["GoogleApi:ApiKey"];
            var apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

            if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret) || string.IsNullOrWhiteSpace(apiKey))
            {
                return StatusCode(500, new { Error = "API credentials are not properly configured." });
            }

            var clientSecrets = new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            try
            {
                // Autorização do Google API
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    new[] { "https://www.googleapis.com/auth/cloud-platform" },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("TokenStore"));

                // Preparar payload
                var payload = new
                {
                    model = "gemini-1.5-flash",
                    prompt = request.Message,
                    max_tokens = 100
                };

                var client = _httpClientFactory.CreateClient();
                var jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload); // Serializa usando System.Text.Json
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}?key={apiKey}")
                {
                    Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json") // Corrigido o tipo do terceiro argumento
                };

                var response = await client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<MessageResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Error = $"An unexpected error occurred: {ex.Message}" });
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
