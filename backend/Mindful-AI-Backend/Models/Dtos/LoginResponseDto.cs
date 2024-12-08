namespace Mindful_AI_Backend.Models.Dtos
{
    public class LoginResponseDto
    {
        public string Message { get; set; }
        public UserCreateDto User { get; set; }
        public string Token { get; set; }
    }
}
