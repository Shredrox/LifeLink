using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestService _labTestService;

        public LabTestController(ILabTestService labTestService)
        {
            _labTestService = labTestService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLabTest([FromBody] AddLabTestRequestDto request, [FromQuery] int medicalRecordId)
        {
            try
            {
                await _labTestService.AddLabTest(request, medicalRecordId);
                return Ok("Lab test created");
            }
            catch (MedicalRecordNotFoundException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
