using LifeLinkAPI.Application.DTOs.Requests;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface ILabTestService
{
    Task AddLabTest(AddLabTestRequestDto request, int medicalRecordId);
}