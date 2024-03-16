using LifeLinkAPI.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByName(string username)
        {
            var user = await _userService.GetUserByName(username);

            if (user is null)
            {
                return NotFound(); 
            }

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
    }
}
