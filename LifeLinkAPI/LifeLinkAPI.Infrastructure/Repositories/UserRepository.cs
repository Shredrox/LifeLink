using LifeLinkAPI.Application.Interfaces.Repositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserRepository(
        AppDbContext context, 
        UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<User?> GetUserByUsernameOrEmail(string username, string email)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.UserName == username || user.Email == email);
    }
    
    public async Task Add(User user, string password)
    {
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
        
        await _userManager.CreateAsync(user, password);
    }

    public async Task Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}