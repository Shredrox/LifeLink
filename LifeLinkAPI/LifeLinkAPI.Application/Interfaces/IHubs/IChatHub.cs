namespace LifeLinkAPI.Application.Interfaces.IHubs;

public interface IChatHub
{
    Task SendMessage(string user, string message);
    Task SendMessageToGroup(string sender, string receiver, string message);
}