using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly LifeLinkDbContext _context;

    public ChatRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task<List<Chat>> GetChatsByUser1IdOrUser2Id(User user1, User user2)
    {
        return await _context.Chats
            .Include(c => c.User1)
            .Include(c => c.User2)
            .Where(c => c.User1 == user1 || c.User2 == user2)
            .ToListAsync();
    }

    public async Task<Chat?> GetChatByUser1AndUser2(User user1, User user2)
    {
        return await _context.Chats
            .FirstOrDefaultAsync(c => (c.User1 == user1 && c.User2 == user2) || c.User1 == user2 && c.User2 == user1);
    }

    public async Task InsertChat(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
    }
}