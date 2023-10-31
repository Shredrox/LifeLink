using LifeLinkAPI.Models.DTOs;
using LifeLinkAPI.Services;
using LifeLinkAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
