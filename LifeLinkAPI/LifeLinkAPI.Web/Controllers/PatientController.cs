using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.Interfaces;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMedicalDataService _medicalDataService;

        public PatientController(IMedicalDataService medicalDataService)
        {
            _medicalDataService = medicalDataService;
        }

        [Authorize]
        [HttpPost("BookAppointment")]
        public async Task<IActionResult> BookAppointment(AppointmentDTO request)
        {
            
            return Ok();
        }
    }
}
