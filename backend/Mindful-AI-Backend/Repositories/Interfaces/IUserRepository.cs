using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    void DeleteUser(User user); // Novo método
    Task SaveChangesAsync();


}
