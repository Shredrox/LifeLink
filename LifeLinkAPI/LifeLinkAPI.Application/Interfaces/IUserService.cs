using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserById(string id);
        public Task Update(User user);
        public Task<User?> GetUserByName(string name);
        public Task<List<User>> GetAllUsers();
        public Task CreateDoctor(User request);
        public Task CreateHospitalAdmin(User request);
    }
}
