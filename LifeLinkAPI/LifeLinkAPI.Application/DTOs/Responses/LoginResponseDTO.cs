namespace LifeLinkAPI.Application.DTOs.Responses;

public class LoginResponseDTO
{
    public string? Username { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
