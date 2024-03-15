using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeLinkAPI.Application.Services;

public class TokenService : ITokenService
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public TokenService(
        IUserService userService, 
        IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
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
    
    public async Task<string> CreateRefreshToken(User user)
    {
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        user.RefreshToken = refreshToken;
        user.RefreshTokenValidity = DateTime.Now.AddHours(2).ToUniversalTime(); 

        await _userService.UpdateUserRefreshToken(user);

        return refreshToken;
    }
}