using LifeLinkAPI.Models;
using LifeLinkAPI.Models.DTOs;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterPatient(UserDTO request);
        public User? GetUser(UserDTO request);
        public List<User> GetAllUsers();
        public Task CreateDoctor(User request);
        public Task CreateAdmin(User request);
        public Task CreateHospitalAdmin(User request);
    }
}
