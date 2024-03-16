using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] AddPaymentRequestDto request, [FromQuery] int doctorId, [FromQuery] int patientId)
        {
            await _paymentService.CreatePayment(request, doctorId, patientId);
            return Ok("Payment created");
        }
        
        [HttpGet("/patient/{patientId:int}")]
        public async Task<IActionResult> GetPaymentsByPatientId(int patientId)
        {
            return Ok(await _paymentService.GetPaymentsByPatientId(patientId));
        }
        
        [HttpGet("/doctor/{doctorId:int}")]
        public async Task<IActionResult> GetPaymentsByDoctorId(int doctorId)
        {
            return Ok(await _paymentService.GetPaymentsByDoctorId(doctorId));
        }
    }
}
