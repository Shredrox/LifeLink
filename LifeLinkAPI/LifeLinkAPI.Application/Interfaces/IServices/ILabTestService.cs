using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface ILabTestService
{
    Task<LabTestResponseDto> GetLabTestsByMedicalRecordId(int medicalRecordId);
    Task AddLabTest(AddLabTestRequestDto request, int medicalRecordId);
}