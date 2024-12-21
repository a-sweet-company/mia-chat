using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            var payload = new
            {
                model = "gemini-1.5-flash",
                prompt = request.Message,
                max_tokens = 100
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", credential.Token.AccessToken);

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
