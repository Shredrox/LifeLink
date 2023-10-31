using LifeLinkAPI.Data;
using LifeLinkAPI.Models;
using LifeLinkAPI.Models.DTOs;
using LifeLinkAPI.Services.Interfaces;

namespace LifeLinkAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterPatient(UserDTO request)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Password = passwordHash,
                Email = request.Email,
                Role = Role.Patient
            };

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
                    BirthDate = new DateTime(2023,10,1).ToUniversalTime() 
                },
                User = user
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public User? GetUser(UserDTO request)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == request.Username || user.Email == request.Email);

            if(user == null)
            {
                return null;
            }

            var correctPassword = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);

            if (!correctPassword)
            {
                return null;
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Task CreateAdmin(User request)
        {
            throw new NotImplementedException();
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
