using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository, 
            IPatientRepository patientRepository, 
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _tokenService = tokenService;
        }
        
        public async Task Register(RegisterRequestDto request)
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
                SSN = request.SSN,
                PhoneNumber = request.PhoneNumber,
                MedicalRecord = new MedicalRecord 
                { 
                    Gender = request.Gender, 
                    Address = request.Address, 
                    BirthDate = request.BirthDate
                },
                User = user
            };

            await _patientRepository.Add(patient);
        }
        
        public async Task<LoginResponseDto?> Login(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByUsernameOrEmail(request.Username, request.Email);

            if (user is null || !await _userRepository.CheckPassword(user, request.Password))
            {
                return null;
            }
            
            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = await _tokenService.CreateRefreshToken(user);

            var loginResponseDto = new LoginResponseDto(user.UserName, accessToken, refreshToken);

            return loginResponseDto;
        }
        
        public async Task<User?> GetUserFromRefreshToken(string refreshToken)
        {
            try
            {
                var user = await _userRepository.GetUserByRefreshToken(refreshToken);

                if (user is null)
                {
                    return null;
                }

                return await _userRepository.GetUserById(user.Id);
                
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
