namespace LifeLinkAPI.Application.DTOs.Requests;

public record CreateChatRequestDto(
    string User1Name,
    string User2Name);