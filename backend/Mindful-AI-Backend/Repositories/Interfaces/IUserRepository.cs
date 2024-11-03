using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task SaveChangesAsync();
    Task<User> GetUserByIdAsync(int userId);

}
