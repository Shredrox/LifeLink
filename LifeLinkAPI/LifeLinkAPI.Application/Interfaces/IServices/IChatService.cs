using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface IChatService
{
    Task<List<MessageResponseDto>> GetChatMessages(string user1Name, string user2Name);
    Task<List<ChatResponseDto>> GetUserChats(string username);
    Task<ChatResponseDto> CreateChat(CreateChatRequestDto request);
    Task<MessageResponseDto> CreateMessage(SendMessageRequestDto request);
}