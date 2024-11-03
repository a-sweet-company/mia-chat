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
        // Criptografando a senha
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveChangesAsync();
        return true;
    }

    public async Task<User> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null; // Login falhou

        return user;
    }
}
