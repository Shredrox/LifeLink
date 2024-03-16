using LifeLinkAPI.Application.Interfaces.IHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LifeLinkAPI.Infrastructure.Hubs;

[Authorize]
public class ChatHub : Hub, IChatHub
{
    public override Task OnConnectedAsync()
    {
        var username = Context.User.Identity.Name;
        
        Groups.AddToGroupAsync(Context.ConnectionId, username);
        return base.OnConnectedAsync();
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    
    public async Task SendMessageToGroup(string sender, string receiver, string message)
    {
        await Clients.Group(receiver).SendAsync("ReceivePrivateMessage", sender, message);
    } 
}