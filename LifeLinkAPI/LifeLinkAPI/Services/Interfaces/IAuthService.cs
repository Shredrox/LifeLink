using LifeLinkAPI.Models;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public string CreateToken(User user);
        public Task<string> CreateRefreshToken(User user);
        public Task<User?> GetUserFromRefreshToken(string refreshToken);
    }
}
