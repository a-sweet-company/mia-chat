using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    void DeleteUser(User user); // Novo método
    Task SaveChangesAsync();
    Task GetMessagesByUserAsync(int userId);
    ActionResult<List<Message>> GetMessagesByUserAsync();
    object AddUserAsync();
}
