namespace LifeLinkAPI.Application.DTOs.Requests;

public record RegisterRequestDto(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password,
    string PhoneNumber,
    string Gender,
    string Address);