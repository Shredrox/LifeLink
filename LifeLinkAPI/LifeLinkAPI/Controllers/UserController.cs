using LifeLinkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public ActionResult GetUserByName(string username)
        {
            var user = _userService.GetUserByName(username);

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
