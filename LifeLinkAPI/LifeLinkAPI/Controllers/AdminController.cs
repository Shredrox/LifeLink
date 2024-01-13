using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController()
        {

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("RegisterHospital")]
        public ActionResult RegisterHospital([FromBody] string value)
        {
            return Ok(value);

        }
    }
}
