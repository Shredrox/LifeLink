namespace LifeLinkAPI.Application.DTOs.Requests;

public record AddLabTestRequestDto(
    string Name,
    string Result,
    string Cost);