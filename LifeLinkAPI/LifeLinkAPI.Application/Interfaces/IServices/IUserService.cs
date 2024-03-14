using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<User?> GetUserById(string id);
        public Task Update(User user);
        public Task<User?> GetUserByName(string name);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task CreateDoctor(User request);
        public Task CreateHospitalAdmin(User request);
    }
}
