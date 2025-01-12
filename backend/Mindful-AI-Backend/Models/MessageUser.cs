namespace Mindful_AI_Backend.Models

{
    public class MessageUser : Message
    {
        public User user { get; set; }


        public MessageUser(int messageId, string textMessage, DateTime timestamp, int User)
            : base(messageId, textMessage, timestamp)
        {
            User = User;
        }
    }
    
}
