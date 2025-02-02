﻿using System;
using System.ComponentModel.DataAnnotations;

public class ChatHistory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo mensagem é obrigatório.")]
    public string Message { get; set; }

    public DateTime Timestamp { get; set; }

    [Required]
    public int UserId { get; set; }

    // Relacionamento com o usuário
    public User? User { get; set; }

    public ChatHistory()
    {
        Timestamp = DateTime.UtcNow;
    }
}