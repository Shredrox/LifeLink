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
        
        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> GetMedicalRecordByPatientId(int patientId)
        {
            try
            {
                return Ok(await _medicalRecordService.GetMedicalRecordByPatientId(patientId));
            }
            catch (MedicalRecordNotFoundException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
        
        [Authorize(Roles = "Doctor")]
        [HttpPost("add-diagnosis")]
        public async Task<IActionResult> AddDiagnosis([FromBody] AddDiagnosisRequestDto request, [FromQuery] int medicalRecordId, [FromQuery] int doctorId)
        {
            try
            {
                await _medicalRecordService.AddDiagnosisToMedicalRecord(request, medicalRecordId, doctorId);
                return Ok("Diagnosis added to medical record");
            }
            catch (Exception e) when (e is MedicalRecordNotFoundException or DoctorNotFoundException)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
        
        [Authorize(Roles = "Doctor")]
        [HttpPost("add-prescription")]
        public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionRequestDto request, [FromQuery] int medicalRecordId, [FromQuery] int doctorId)
        {
            try
            {
                await _medicalRecordService.AddPrescriptionToMedicalRecord(request, medicalRecordId, doctorId);
                return Ok("Prescription added to medical record");
            }
            catch (Exception e) when (e is MedicalRecordNotFoundException or DoctorNotFoundException)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}