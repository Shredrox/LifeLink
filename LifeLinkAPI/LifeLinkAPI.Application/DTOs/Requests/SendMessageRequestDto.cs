namespace LifeLinkAPI.Application.DTOs.Requests;

public record SendMessageRequestDto(
    string Content,
    string Sender,
    string Receiver);