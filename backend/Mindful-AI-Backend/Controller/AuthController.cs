using Microsoft.AspNetCore.Mvc;
using Mindful_AI_Backend.Models.Dtos;
using System.Threading.Tasks;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            Password = userDto.Password
        };

        var success = await _authService.Register(user);
        if (!success) return BadRequest("Erro ao registrar usuário.");
        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _authService.Login(request.Email, request.Password);
        if (user == null) return Unauthorized(new { error = "Credenciais inválidas." });

        return Ok(new { message = "Login bem-sucedido.", user = new { user.Id, user.Email } });
    }

}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
