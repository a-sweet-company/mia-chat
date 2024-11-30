using System.Threading.Tasks;
using BCrypt.Net;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Register(User user)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null) return false; // Usuário já existe

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao registrar usuário: {ex.Message}");
            return false; // Você pode lançar a exceção ou retornar false
        }
    }


    public async Task<User> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null; // Login falhou

        return user;
    }
}
