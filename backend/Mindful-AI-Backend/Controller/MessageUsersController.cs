using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mindful_AI_Backend.Models;
using NuGet.Protocol.Plugins;

namespace Mindful_AI_Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageUsersController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public MessageUsersController(ApplicationDbContext context)
        {

            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<MessageUser>> Get()
        {
            var messages = _context.MessageUsers.ToList();

            if (messages is null)
            {
                return NotFound("Mensagens não encontradas");
            }
            return messages;
        }

        [HttpGet("{id}")]
        public ActionResult<MessageUser> Get(int id)
        {

         var message = _context.MessageUsers.FirstOrDefault(m => m.messageId == id);
            if (message is null)
            {
                return NotFound("Mensagem nao encontrada");
            }
            return message;
        }

        [HttpPost]
        public ActionResult<MessageUser> Post(MessageUser messageUser)
        {

            if (messageUser is null)
            {
                return BadRequest();
            }

            _context.MessageUsers.Add(messageUser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), 
                new { id = messageUser.messageId }, messageUser);

           
        }

         


    }
}
