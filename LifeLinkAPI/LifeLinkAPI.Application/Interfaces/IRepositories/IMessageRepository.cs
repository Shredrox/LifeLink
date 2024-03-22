using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IMessageRepository
{
    Task<List<Message>> GetMessagesBySenderOrReceiver(User user1, User user2);
    Task InsertMessage(Message message);
}