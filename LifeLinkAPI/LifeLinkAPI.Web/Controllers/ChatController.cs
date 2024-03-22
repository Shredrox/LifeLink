using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IClients;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Infrastructure.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;
        private readonly IChatService _chatService;
        
        public ChatController(
            IHubContext<ChatHub, IChatClient> hubContext, 
            IChatService chatService)
        {
            _hubContext = hubContext;
            _chatService = chatService;
        }

        [HttpGet("get-messages")]
        public async Task<IActionResult> GetMessages([FromQuery] string user, [FromQuery] string chatUser)
        {
            return Ok(await _chatService.GetChatMessages(user, chatUser));
        }
    
        [HttpGet("get-user-chats")]
        public async Task<IActionResult> GetUserChats([FromQuery] string username)
        {
            return Ok(await _chatService.GetUserChats(username));
        }
    
        [HttpPost("create-chat")]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatRequestDto request)
        {
            var chatResponse = await _chatService.CreateChat(request);
        
            await _hubContext.Clients.Group(request.User2Name).ChatCreated(chatResponse);
        
            return Ok();
        }
    
        [HttpPost("send-private-message")]
        public async Task<IActionResult> SendPrivateMessage([FromBody] SendMessageRequestDto request)
        {
            var messageResponse = await _chatService.CreateMessage(request);
        
            await _hubContext.Clients.Group(request.Receiver).ReceiveMessage(messageResponse);
        
            return Ok();
        }
    }
}
