using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameOrEmail(string username, string email);
    Task<List<User>> GetAllUsers();
    Task<User?> GetUserById(string id);
    Task<bool> CheckPassword(User user, string password);
    Task Add(User user, string password);
    Task Update(User user);
}