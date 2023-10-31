using LifeLinkAPI.Data;
using LifeLinkAPI.Models;
using LifeLinkAPI.Models.DTOs;
using LifeLinkAPI.Services.Interfaces;

namespace LifeLinkAPI.Services
{
    public class MedicalDataService : IMedicalDataService
    {
        private readonly AppDbContext _context;

        public MedicalDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAppointment(AppointmentDTO request)
        {
            
            await _context.SaveChangesAsync();
        }
    }
}
