using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface ITokenService
{
    string CreateToken(User user);
    Task<string> CreateRefreshToken(User user);
}