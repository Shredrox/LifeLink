namespace LifeLinkAPI.Application.DTOs.Requests;

public record LoginRequestDto(
    string Username,
    string Email,
    string Password);