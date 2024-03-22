using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface IAppointmentService
{
    Task<AppointmentHoursResponseDto> GetAllAppointmentHoursByDoctorAndDate(int doctorId, DateTime date);
    Task CreateAppointment(BookAppointmentRequestDto request);
    Task UpdateAppointment(UpdateAppointmentRequestDto request);
    Task DeleteAppointment(int appointmentId);
}