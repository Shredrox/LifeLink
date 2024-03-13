using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IAppointmentRepository
{
    Task CreateAppointment(Appointment appointment);
    Task<List<Appointment>> GetAllAppointmentsByDoctorAndDate(int doctorId, DateTime date);
}