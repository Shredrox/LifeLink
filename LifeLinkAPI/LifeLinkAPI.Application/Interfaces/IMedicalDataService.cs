using LifeLinkAPI.Application.DTOs;

namespace LifeLinkAPI.Application.Interfaces
{
    public interface IMedicalDataService
    {
        public Task CreateAppointment(AppointmentDTO request);
    }
}
