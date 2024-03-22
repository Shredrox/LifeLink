namespace LifeLinkAPI.Application.DTOs;

public record LabTestDto(
    string Name,
    string ResultStatus,
    string Result,
    string Cost);