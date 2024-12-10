using Microsoft.AspNetCore.Mvc;
using Mindful_AI_Backend.Models.Dtos;
using System.ComponentModel.DataAnnotations;
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            // Criação do usuário
            var user = new User
            {
                Email = userDto.Email
            };
            user.SetPassword(userDto.Password); // Hash da senha

            var success = await _authService.Register(user);
            if (!success)
                return BadRequest("Erro ao registrar usuário. O email já está em uso.");

            return Ok(new { message = "Usuário registrado com sucesso!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Erro interno do servidor.", details = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _authService.Login(request.Email, request.Password);
            if (user == null)
                return Unauthorized(new { error = "Credenciais inválidas." });

            return Ok(new { message = "Login bem-sucedido.", user = new { user.Id, user.Email } });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Erro interno do servidor.", details = ex.Message });
        }
    }
}

public class LoginRequest
{
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo Email deve conter um endereço válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    public string Password { get; set; }
}
