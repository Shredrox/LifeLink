using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAndDate(int doctorId, DateTime date);
    Task<Appointment?> GetAppointmentsById(int appointmentId);
    Task InsertAppointment(Appointment appointment);
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(int appointmentId);
}