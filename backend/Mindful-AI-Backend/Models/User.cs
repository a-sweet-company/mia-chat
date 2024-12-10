using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo Email deve conter um endereço válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
    public string Password { get; set; } 

    public List<ChatHistory> ChatHistories { get; set; } = new List<ChatHistory>();

    // Método para verificar a senha
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Password); 
    }

    // Método para definir a senha
    public void SetPassword(string password)
    {
        Password = BCrypt.Net.BCrypt.HashPassword(password); // Armazenando a senha criptografada
    }
}
