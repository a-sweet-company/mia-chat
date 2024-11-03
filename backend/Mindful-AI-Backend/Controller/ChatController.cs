using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public ChatController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("history/{userId}")]
    public async Task<IActionResult> GetChatHistory(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null) return NotFound("Usuário não encontrado.");

        return Ok(user.ChatHistories);
    }

    [HttpPost("history/{userId}")]
    public async Task<IActionResult> AddChatMessage(int userId, [FromBody] ChatHistory message)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null) return NotFound("Usuário não encontrado.");

        user.ChatHistories.Add(message);
        await _userRepository.SaveChangesAsync();

        return Ok("Mensagem adicionada ao histórico.");
    }
}
