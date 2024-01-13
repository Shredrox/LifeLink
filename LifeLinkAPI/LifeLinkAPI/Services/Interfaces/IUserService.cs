using LifeLinkAPI.Models;
using LifeLinkAPI.Models.DTOs;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterPatient(UserDTO request);
        public User? GetUser(UserDTO request);
        public Task<User?> GetUserById(int id);
        public Task Update(User user);
        public User? GetUserByName(string name);
        public List<User> GetAllUsers();
        public Task RegisterAdmin();
        public Task CreateDoctor(User request);
        public Task CreateAdmin(User request);
        public Task CreateHospitalAdmin(User request);
    }
}
