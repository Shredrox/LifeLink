using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.Interfaces.IServices;

namespace LifeLinkAPI.Application.Services
{
    public class MedicalDataService : IMedicalDataService
    {

        public MedicalDataService()
        {
        }

        public Task CreateAppointment(AppointmentDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
