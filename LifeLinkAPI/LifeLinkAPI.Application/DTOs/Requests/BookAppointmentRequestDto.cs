namespace LifeLinkAPI.Application.DTOs.Requests;

public record BookAppointmentRequestDto(
    int DoctorId,
    int PatientId,
    int AppointmentHourId,
    DateTime Date);