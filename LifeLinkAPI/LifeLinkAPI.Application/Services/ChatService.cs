using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(
        IChatRepository chatRepository, 
        IUserRepository userRepository, 
        IMessageRepository messageRepository)
    {
        _chatRepository = chatRepository;
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }

    public async Task<List<MessageResponseDto>> GetChatMessages(string user1Name, string user2Name)
    {
        var user1 = await _userRepository.GetUserByUsernameOrEmail(user1Name, "");
        var user2 = await _userRepository.GetUserByUsernameOrEmail(user1Name, "");

        if (user1 is null || user2 is null)
        {
            throw new UserNotFoundException();
        }

        var messages = await _messageRepository.GetMessagesBySenderOrReceiver(user1, user2);

        var response = messages
            .Select(m => new MessageResponseDto(
                m.Content, 
                m.Sender.UserName,
                m.Receiver.UserName, 
                m.Timestamp.ToString("dd-MM-yyyy HH:mm"))
            )
            .ToList();

        return response;
    }

    public async Task<List<ChatResponseDto>> GetUserChats(string username)
    {
        var user = await _userRepository.GetUserByUsernameOrEmail(username, "");
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var chats = await _chatRepository.GetChatsByUser1IdOrUser2Id(user, user);

        var response = chats
            .Select(c => new ChatResponseDto(c.User1.UserName, c.User2.UserName))
            .ToList();
        
        return response;
    }

    public async Task<ChatResponseDto> CreateChat(CreateChatRequestDto request)
    {
        var user1 = await _userRepository.GetUserById(request.User1Name);
        var user2 = await _userRepository.GetUserById(request.User2Name);

        if (user1 is null || user2 is null)
        {
            throw new UserNotFoundException();
        }
        
        var chat = new Chat
        {
            User1 = user1,
            User2 = user2,
            CreatedAt = DateTime.Now.ToUniversalTime()
        };

        await _chatRepository.InsertChat(chat);

        return new ChatResponseDto(
            chat.User1.UserName,
            chat.User2.UserName);
    }

    public async Task<MessageResponseDto> CreateMessage(SendMessageRequestDto request)
    {
        var user1 = await _userRepository.GetUserByUsernameOrEmail(request.Sender, "");
        var user2 = await _userRepository.GetUserByUsernameOrEmail(request.Receiver, "");
        
        if (user1 is null || user2 is null)
        {
            throw new UserNotFoundException();
        }

        var chat = await _chatRepository.GetChatByUser1AndUser2(user1, user2);

        if (chat is null)
        {
            throw new ChatNotFoundException();
        }
        
        var message = new Message
        {
            Content = request.Content,
            Chat = chat,
            Sender = user1,
            Receiver = user2,
            Timestamp = DateTime.Now.ToUniversalTime()
        };

        await _messageRepository.InsertMessage(message);

        return new MessageResponseDto(
            message.Content, 
            message.Sender.UserName, 
            message.Receiver.UserName,
            message.Timestamp.ToString("dd-MM-yyyy HH:mm")
            );
    }
}