using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAndDate(int doctorId, DateTime date);
    Task InsertAppointment(Appointment appointment);
}