using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameOrEmail(string username, string email);
    Task<User?> GetUserByRefreshToken(string refreshToken);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User?> GetUserById(string id);
    Task<bool> CheckPassword(User user, string password);
    Task InsertUser(User user, string password);
    Task UpdateUser(User user);
}