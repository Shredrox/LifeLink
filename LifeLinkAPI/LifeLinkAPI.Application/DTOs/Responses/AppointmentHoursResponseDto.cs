namespace LifeLinkAPI.Application.DTOs.Responses;

public record AppointmentHoursResponseDto(
    List<AppointmentHourDto> AppointmentHours);