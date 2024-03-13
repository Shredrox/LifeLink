namespace LifeLinkAPI.Application.DTOs.Requests;

public record RegisterDoctorRequestDto(
    string Username,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Specialty,
    string Experience,
    int Age,
    string PhoneNumber,
    string WorkHours,
    string AppointmentHours);