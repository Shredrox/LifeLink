﻿using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IChatRepository
{
    Task<List<Chat>> GetChatsByUser1IdOrUser2Id(User user1, User user2);
    Task<Chat?> GetChatByUser1AndUser2(User user1, User user2);
    Task InsertChat(Chat chat);
}