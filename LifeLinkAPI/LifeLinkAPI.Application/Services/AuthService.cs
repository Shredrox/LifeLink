using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeLinkAPI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, 
            IUserService userService, 
            IUserRepository userRepository, 
            IPatientRepository patientRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        
        public async Task Register(UserDTO request)
        {
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                Role = Role.Patient
            };

            await _userRepository.Add(user, request.Password);

            var patient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                SSN = "1",
                PhoneNumber = request.PhoneNumber,
                MedicalRecord = new MedicalRecord 
                { 
                    Gender = request.Gender, 
                    Address = request.Address, 
                    BirthDate = DateTime.Now.ToUniversalTime()
                },
                User = user
            };

            await _patientRepository.Add(patient);
        }
        
        public async Task<LoginResponseDTO?> Login(UserDTO request)
        {
            var user = await _userRepository.GetUserByUsernameOrEmail(request.Username, request.Email);

            if (user is null || !await _userRepository.CheckPassword(user, request.Password))
            {
                return null;
            }
            
            var token = CreateToken(user);
            var refreshToken = await CreateRefreshToken(user);

            var loginResponseDto = new LoginResponseDTO
            {
                Username = user.UserName,
                AccessToken = token,
                RefreshToken = refreshToken
            };

            return loginResponseDto;
        }

        public async Task<string> CreateRefreshToken(User user)
        {
            try
            {
                var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

                user.RefreshToken = refreshToken;
                user.RefreshTokenValidity = DateTime.Now.AddHours(2).ToUniversalTime(); 

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

        public Task<User?> GetUserFromRefreshToken(string refreshToken)
        {
            try
            {
                // var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenValidity > DateTime.Now.ToUniversalTime());
                //
                // if (user != null)
                // {
                //     return await _userService.GetUserById(user.Id);
                // }

                return null;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
