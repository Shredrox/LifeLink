using LifeLinkAPI.Application.DTOs.Requests;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IMedicalRecordService
    {
        Task AddDiagnosisToMedicalRecord(AddDiagnosisRequestDto request, int medicalRecordId);
    }
}
