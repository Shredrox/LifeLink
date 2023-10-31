using LifeLinkAPI.Models.DTOs;
using LifeLinkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(
            IUserService userService,
            IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userService.RegisterPatient(request);

            return CreatedAtAction("Register", "Patient Registered");
        }

        [HttpPost("Login")]
        public ActionResult Login(UserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //check user
            var user = _userService.GetUser(request);

            if(user is null)
            {
                return BadRequest();
            }

            string token = _authService.CreateToken(user);
            Response.Cookies.Append("token", token, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true,
                IsEssential = true
            });

            return Ok(token);
        }

        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
    }
}
