using System;
using System.ComponentModel.DataAnnotations;

public class ChatHistoryDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo mensagem é obrigatório.")]
    public string Message { get; set; }

    public DateTime Timestamp { get; set; }
}