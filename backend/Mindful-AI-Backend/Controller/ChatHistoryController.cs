using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Mindful_AI_Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Mindful_AI_Backend.Models;

[ApiController]
[Route("api/[controller]")]
public class ChatHistoryController : ControllerBase
{
    //private readonly IUserRepository _userRepository;

    //public ChatHistoryController(IUserRepository userRepository)
    //{
    //    _userRepository = userRepository;
    //}


    private readonly ApplicationDbContext _context;

    public ChatHistoryController(ApplicationDbContext context)
    {

        _context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<ChatHistory>> Get()
    {
        var chat = _context.ChatsHistories.ToList();

        if (chat is null)
        {
            return BadRequest("chat não encontrado");
        }
        return chat;
    }

    [HttpPost]
    public ActionResult<ChatHistory> Post(ChatHistory chatHistory)
    {

        if (chatHistory is null)
        {
            return BadRequest();
        }

        _context.ChatsHistories.Add(chatHistory);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get),
            new { id = chatHistory.Id }, chatHistory);
    }


    //[HttpGet("history/{userId}")]
    //public async Task<IActionResult> GetChatHistory(int userId)
    //{
    //    var user = await _userRepository.GetUserByIdAsync(userId);
    //    if (user == null)
    //        return NotFound(new { error = "Usuário não encontrado." });

    //    var chatHistoryDtos = user.ChatHistories.Select(ch => new ChatHistoryDto
    //    {
    //        Id = ch.Id,
    //        Message = ch.Message,
    //        Timestamp = ch.Timestamp
    //    }).ToList();

    //    return Ok(chatHistoryDtos);
    //}

    //[HttpPost("history/{userId}")]
    //public async Task<IActionResult> AddChatMessage(int userId, [FromBody] ChatHistoryDto messageDto)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var user = await _userRepository.GetUserByIdAsync(userId);
    //    if (user == null)
    //        return NotFound(new { error = "Usuário não encontrado." });

    //    var chatHistory = new ChatHistory
    //    {
    //        Message = messageDto.Message,
    //        Timestamp = DateTime.UtcNow,
    //        UserId = userId
    //    };

    //    user.ChatHistories.Add(chatHistory);
    //    await _userRepository.SaveChangesAsync();

    //    return Ok(new { message = "Mensagem adicionada ao histórico." });
    //}
}