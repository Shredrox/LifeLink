using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IAuthService
    {
        Task Register(UserDTO request);
        Task<LoginResponseDto?> Login(UserDTO request);
        public string CreateToken(User user);
        public Task<string> CreateRefreshToken(User user);
        public Task<User?> GetUserFromRefreshToken(string refreshToken);
    }
}
