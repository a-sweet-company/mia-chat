using System.ComponentModel.DataAnnotations;

public class ChatHistory
{
    public int Id { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }

    // Relacionamento com o usuário (opcional ou obrigatório)
    public User? User { get; set; }
}

