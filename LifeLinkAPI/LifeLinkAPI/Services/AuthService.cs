using LifeLinkAPI.Data;
using LifeLinkAPI.Models;
using LifeLinkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LifeLinkAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, AppDbContext context, IUserService userService)
        {
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }

        public async Task<string> CreateRefreshToken(User user)
        {
            try
            {
                var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

                user.RefreshToken = refreshToken;
                user.RefreshTokenValidity = DateTime.Now.AddHours(2).ToUniversalTime(); // Refresh token valid for 2 hours

                await _userService.Update(user);

                return refreshToken;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<User?> GetUserFromRefreshToken(string refreshToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenValidity > DateTime.Now.ToUniversalTime());

                if (user != null)
                {
                    return await _userService.GetUserById(user.Id);
                }

                return null;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
