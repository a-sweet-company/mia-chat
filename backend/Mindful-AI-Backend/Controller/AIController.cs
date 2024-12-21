using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeminiController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var apiKey = "AIzaSyBQQmhdqh36HqSdNduCzw8JNV6kTsYq3rA";
            var apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=AIzaSyBQQmhdqh36HqSdNduCzw8JNV6kTsYq3rA\"";

            var payload = new
            {
                model = "gemini-1.5-flash",
                prompt = request.Message,
                max_tokens = 100
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await _httpClient.PostAsync(apiUrl, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<MessageResponse>(responseContent);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, responseContent);
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
