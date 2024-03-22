using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        [HttpGet("hours")]
        public async Task<IActionResult> GetAppointmentHours([FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            return Ok(await _appointmentService.GetAllAppointmentHoursByDoctorAndDate(doctorId, date));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] BookAppointmentRequestDto request)
        {
            await _appointmentService.CreateAppointment(request);
            return Ok("Appointment created");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] BookAppointmentRequestDto request)
        {
            await _appointmentService.CreateAppointment(request);
            return Ok("Appointment created");
        }
        
        [HttpDelete("{appointmentId:int}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            await _appointmentService.DeleteAppointment(appointmentId);
            return Ok("Appointment deleted");
        }
    }
}
