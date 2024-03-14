using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IServices
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecord> GetMedicalRecordByPatientId(int patientId);
        Task AddDiagnosisToMedicalRecord(AddDiagnosisRequestDto request, int medicalRecordId, int doctorId);
        Task AddPrescriptionToMedicalRecord(AddPrescriptionRequestDto request, int medicalRecordId, int doctorId);
    }
}
