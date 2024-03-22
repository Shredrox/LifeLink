namespace LifeLinkAPI.Application.DTOs.Requests;

public record UpdateAppointmentRequestDto(
    int AppointmentId,
    DateTime Date);