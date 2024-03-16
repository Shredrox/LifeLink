using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestService _labTestService;

        public LabTestController(ILabTestService labTestService)
        {
            _labTestService = labTestService;
        }
        
        [HttpGet("{medicalRecordId:int}")]
        public async Task<IActionResult> GetLabTests(int medicalRecordId)
        {
            return Ok(await _labTestService.GetLabTestsByMedicalRecordId(medicalRecordId));
        }

        [Authorize(Roles = "Doctor")]
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
        
        [Authorize(Roles = "Doctor")]
        [HttpPost("add-result")]
        public async Task<IActionResult> AddLabTestResult([FromBody] AddLabTestResultRequestDto request, [FromQuery] int labTestId)
        {
            try
            {
                await _labTestService.AddLabTestResult(request, labTestId);
                return Ok("Lab test created");
            }
            catch (LabTestNotFoundException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
