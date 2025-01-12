using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mindful_AI_Backend.Models
{
    [Table("Message")]
    public abstract class Message
    {
        [Key]
        public int messageId { get; set; }
        public string textmMessage { get; set; }
        public DateTime Timestamp { get; set; }

        // Construtor parametrizado para uso em classes derivadas
        protected Message(int messageId, string textMessage, DateTime timestamp)
        {
            messageId = messageId;
            textMessage = textMessage;
            timestamp = timestamp;
        }

        public Message() { }
       
       
    }

}

