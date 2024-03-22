using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IClients;

public interface IChatClient
{
    Task ReceiveMessage(MessageResponseDto message);
    Task ChatCreated(ChatResponseDto chat);
}