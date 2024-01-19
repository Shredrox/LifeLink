using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.Interfaces;
using LifeLinkAPI.Application.Interfaces.Repositories;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;

        public UserService(
            IUserRepository userRepository, 
            IPatientRepository patientRepository)
        {
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }

        public async Task RegisterDoctor(UserDTO request)
        {
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                Role = Role.Doctor
            };

            await _userRepository.Add(user, request.Password);
            
            //TO DO: Implement Doctor registering
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task Update(User user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id);

            if(existingUser == null)
            {
                return;
            }

            existingUser.RefreshToken = user.RefreshToken;
            existingUser.RefreshTokenValidity = user.RefreshTokenValidity;

            await _userRepository.Update(user);
        }

        public async Task<User?> GetUserByName(string name)
        {
            return await _userRepository.GetUserByUsernameOrEmail(name, "");
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public Task CreateDoctor(User request)
        {
            throw new NotImplementedException();
        }

        public Task CreateHospitalAdmin(User request)
        {
            throw new NotImplementedException();
        }
    }
}
