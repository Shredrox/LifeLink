namespace LifeLinkAPI.Application.DTOs.Responses;

public record LoginResponseDto(
    string Username,
    string AccessToken,
    string RefreshToken);