namespace LifeLinkAPI.Application.DTOs.Requests;

public record AddDiagnosisRequestDto(
    string Name,
    string Description,
    string IllnessName);