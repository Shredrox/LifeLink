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
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] BookAppointmentRequestDto request)
        {
            await _appointmentService.CreateAppointment(request);
            return Ok("Appointment created");
        }
        
        [HttpGet("hours")]
        public async Task<IActionResult> GetAppointmentHours([FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            return Ok(await _appointmentService.GetAllAppointmentHoursByDoctorAndDate(doctorId, date));
        }
    }
}
