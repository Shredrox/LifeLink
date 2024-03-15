namespace LifeLinkAPI.Application.Interfaces.IHubs;

public interface IChatHub
{
    Task SendMessage(string user, string message);
}