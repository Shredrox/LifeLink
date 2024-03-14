using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("add-diagnosis")]
        public async Task<IActionResult> AddDiagnosis([FromBody] AddDiagnosisRequestDto request, [FromQuery] int medicalRecordId)
        {
            try
            {
                await _medicalRecordService.AddDiagnosisToMedicalRecord(request, medicalRecordId);
                return Ok("Diagnosis added to medical record");
            }
            catch (MedicalRecordNotFoundException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}