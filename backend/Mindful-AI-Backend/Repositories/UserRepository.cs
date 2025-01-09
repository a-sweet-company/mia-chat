using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public object AddUserAsync()
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public Task GetMessagesByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public ActionResult<List<Message>> GetMessagesByUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.ChatHistories)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.ChatHistories)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}