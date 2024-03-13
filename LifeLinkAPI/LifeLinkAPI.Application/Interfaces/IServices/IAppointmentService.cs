using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface IAppointmentService
{
    Task CreateAppointment(BookAppointmentRequestDto request);
    Task<AppointmentHoursResponseDto> GetAllAppointmentHoursByDoctorAndDate(int doctorId, DateTime date);
}