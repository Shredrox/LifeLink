using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize(Roles = "Patient, Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMedicalDataService _medicalDataService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(
            IMedicalDataService medicalDataService, 
            IAppointmentService appointmentService)
        {
            _medicalDataService = medicalDataService;
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] CreateAppointmentRequestDto request)
        {
            return Ok("Appointment created");
        }
    }
}
