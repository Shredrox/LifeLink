using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IAppointmentHourRepository
{
    Task<AppointmentHour?> GetAppointmentHourById(int id);
    Task<IEnumerable<AppointmentHour>> GetAppointmentHoursByDoctor(int doctorId);
    Task InsertAppointmentHour(AppointmentHour appointmentHour);
}