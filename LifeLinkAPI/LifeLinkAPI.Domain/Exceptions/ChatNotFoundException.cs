﻿namespace LifeLinkAPI.Domain.Exceptions;

public class ChatNotFoundException : Exception
{
    public ChatNotFoundException()
    {
    }

    public ChatNotFoundException(string message) 
        : base(message)
    {
    }
    
    public ChatNotFoundException(string message, Exception inner) 
        : base(message, inner)
    {
    }
}