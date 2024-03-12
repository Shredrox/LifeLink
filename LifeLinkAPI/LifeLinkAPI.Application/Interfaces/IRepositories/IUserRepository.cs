using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameOrEmail(string username, string email);
    Task<User?> GetUserByRefreshToken(string refreshToken);
    Task<List<User>> GetAllUsers();
    Task<User?> GetUserById(string id);
    Task<bool> CheckPassword(User user, string password);
    Task Add(User user, string password);
    Task Update(User user);
}