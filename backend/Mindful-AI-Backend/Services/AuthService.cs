using System.Threading.Tasks;

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
            // Verifica se o usuário já existe
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
                return false;

            // Define a senha criptografada usando o método SetPassword do modelo User
            user.SetPassword(user.Password); // Usando o campo Password, não PasswordHash

            // Adiciona o usuário no banco de dados
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao registrar usuário: {ex.Message}");
            return false; // Retorna false em caso de erro
        }
    }

    public async Task<User> Login(string email, string password)
    {
        // Busca o usuário pelo email
        var user = await _userRepository.GetUserByEmailAsync(email);

        // Verifica se o usuário existe e se a senha é válida
        if (user == null || !user.VerifyPassword(password))  // Usando o método VerifyPassword, que já usa o campo Password
            return null;

        return user;
    }
}
