using Mindful_AI_Backend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ChatHistory")]
public class ChatHistory
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo mensagem é obrigatório.")]
    public List<Message> Message { get; set; }

    
    public ChatHistory() { }
}

