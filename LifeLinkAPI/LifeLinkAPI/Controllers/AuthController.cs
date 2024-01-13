using LifeLinkAPI.Models.DTOs;
using LifeLinkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        
         public AuthController(
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
        public async Task<IActionResult> Login(UserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _userService.GetUser(request);

            if(user is null)
            {
                return NotFound();
            }

            var token = _authService.CreateToken(user);
            var refreshToken = await _authService.CreateRefreshToken(user);

            Response.Cookies.Append("AccessToken", token, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(15),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            });

            Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            });

            var username = user.Username;

            return Ok(new { token, username });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = Request.Cookies["RefreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest("Refresh token is required");
            }

            var user = await _authService.GetUserFromRefreshToken(refreshToken);

            if (user is null)
            {
                Response.Cookies.Delete("RefreshToken");
                return NoContent();
            }

            user.RefreshToken = null;
            user.RefreshTokenValidity = null;

            await _userService.Update(user);

            return NoContent();
        }
        
        [HttpPost("RefreshToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest("Refresh token is required");
            }

            var user = await _authService.GetUserFromRefreshToken(refreshToken);

            if (user is null)
            {
                return BadRequest("Invalid refresh token");
            }

            var username = user.Username;
            var newAccessToken = _authService.CreateToken(user);
            var newRefreshToken = await _authService.CreateRefreshToken(user);

            Response.Cookies.Append("AccessToken", newAccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(15),
                Domain = "localhost",
                IsEssential = true,
                SameSite = SameSiteMode.None
            });
            Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(1),
                Domain = "localhost",
                IsEssential = true,
                SameSite = SameSiteMode.None
            });
            return Ok(new {newAccessToken, username });
        }
    }
}
