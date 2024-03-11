using LifeLinkAPI.Application.DTOs;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IMedicalDataService
    {
        public Task CreateAppointment(AppointmentDTO request);
    }
}
