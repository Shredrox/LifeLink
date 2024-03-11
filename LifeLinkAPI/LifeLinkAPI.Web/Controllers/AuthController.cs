using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model state");
                }

                await _authService.Register(request);

                return Ok("User Registered");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during user registration.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model state");
                }

                var response = await _authService.Login(request);

                if (response is null)
                {
                    return Unauthorized("Invalid credentials");
                }

                var token = response.AccessToken;
                var refreshToken = response.RefreshToken;

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

                var username = response.Username;

                return Ok(new { token, username });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during user login.");
            }
        }

        [HttpPost("logout")]
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

            Response.Cookies.Delete("RefreshToken");
            
            user.RefreshToken = null;
            user.RefreshTokenValidity = null;

            await _userService.Update(user);

            return NoContent();
        }
        
        [HttpPost("refresh-token")]
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

            var username = user.UserName;
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
