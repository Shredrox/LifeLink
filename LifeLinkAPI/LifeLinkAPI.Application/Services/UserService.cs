using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }
        
        public async Task<User?> GetUserByName(string name)
        {
            return await _userRepository.GetUserByUsernameOrEmail(name, "");
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        
        public async Task UpdateUserRefreshToken(User user)
        {
            var existingUser = await _userRepository.GetUserById(user.Id);

            if(existingUser == null)
            {
                return;
            }

            existingUser.RefreshToken = user.RefreshToken;
            existingUser.RefreshTokenValidity = user.RefreshTokenValidity;

            await _userRepository.UpdateUser(user);
        }
    }
}
