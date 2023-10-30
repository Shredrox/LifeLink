using LifeLinkAPI.Models;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public string CreateToken(User user);
    }
}
