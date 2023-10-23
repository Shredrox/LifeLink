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
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
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
