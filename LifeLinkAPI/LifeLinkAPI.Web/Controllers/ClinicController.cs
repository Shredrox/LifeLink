using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPost("/register")]
        public ActionResult RegisterClinic([FromBody] string value)
        {
            return Ok(value);
        }
    }
}
