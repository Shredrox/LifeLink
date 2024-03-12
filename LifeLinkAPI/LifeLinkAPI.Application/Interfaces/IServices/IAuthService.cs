using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IAuthService
    {
        Task Register(RegisterRequestDto request);
        Task<LoginResponseDto?> Login(LoginRequestDto request);
        Task<User?> GetUserFromRefreshToken(string refreshToken);
    }
}
