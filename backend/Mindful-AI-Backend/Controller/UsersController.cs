using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mindful_AI_Backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Mindful_AI_Backend.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var userDtos = new List<UserCreateDto>();

        foreach (var user in users)
        {
            userDtos.Add(new UserCreateDto
            {
                Id = user.Id,
                Email = user.Email
            });
        }

        return Ok(userDtos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            return NotFound(new { error = "Usuário não encontrado." });

        _userRepository.DeleteUser(user);
        await _userRepository.SaveChangesAsync();

        return Ok(new { message = "Usuário excluído com sucesso." });
    }

}