using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IAppointmentHourRepository
{
    Task<AppointmentHour?> GetAppointmentHourById(int id);
    Task<List<AppointmentHour>> GetAllAppointmentHoursByDoctor(int doctorId);
}