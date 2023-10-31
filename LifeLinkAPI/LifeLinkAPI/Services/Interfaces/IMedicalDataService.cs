using LifeLinkAPI.Models.DTOs;

namespace LifeLinkAPI.Services.Interfaces
{
    public interface IMedicalDataService
    {
        public Task CreateAppointment(AppointmentDTO request);
    }
}
