using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<User?> GetUserById(string id);
        public Task<User?> GetUserByName(string name);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task UpdateUserRefreshToken(User user);
    }
}
