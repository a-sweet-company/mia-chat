using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GeminiController.Controllers
{
    [ApiController]
    [Route("api/gemini")]
    public class AIController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

        public AIController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiKey = _configuration["GoogleApi:ApiKey"];
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Message))
            {
                return BadRequest(new { Error = "Message cannot be null or empty." });
            }

            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                return StatusCode(500, new { Error = "API key is not properly configured." });
            }

            try
            {
                var payload = new
                {
                    contents = new[]
                    {
                        new
                        {
                            role = "user",
                            parts = new[]
                            {
                                new
                                {
                                    text = request.Message
                                }
                            }
                        }
                    }
                };

                var client = _httpClientFactory.CreateClient();
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var jsonPayload = JsonSerializer.Serialize(payload, jsonOptions);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}?key={_apiKey}")
                {
                    Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
                };

                // Adicionar log do payload para debug
                Console.WriteLine($"Request Payload: {jsonPayload}");

                var response = await client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                // Adicionar log da resposta para debug
                Console.WriteLine($"API Response: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    using var document = JsonDocument.Parse(responseContent);
                    var root = document.RootElement;

                    if (root.TryGetProperty("candidates", out var candidates) &&
                        candidates.GetArrayLength() > 0 &&
                        candidates[0].TryGetProperty("content", out var content) &&
                        content.TryGetProperty("parts", out var parts) &&
                        parts.GetArrayLength() > 0 &&
                        parts[0].TryGetProperty("text", out var textElement))
                    {
                        var responseText = textElement.GetString();
                        return Ok(new MessageResponse { Text = responseText });
                    }
                    else
                    {
                        return StatusCode(500, new { Error = "Unexpected response structure", Response = responseContent });
                    }
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
            catch (Exception ex)
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