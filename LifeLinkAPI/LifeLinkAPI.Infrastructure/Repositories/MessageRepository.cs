using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly LifeLinkDbContext _context;

    public MessageRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetMessagesBySenderOrReceiver(User user1, User user2)
    {
        return await _context.Messages
            .Where(m => m.Sender == user1 && m.Receiver == user2 || (m.Sender == user2 && m.Receiver == user1))
            .ToListAsync();
    }

    public async Task InsertMessage(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}