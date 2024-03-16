namespace LifeLinkAPI.Application.DTOs;

public record LabTestDto(
    string Name,
    string? Result,
    string Cost);