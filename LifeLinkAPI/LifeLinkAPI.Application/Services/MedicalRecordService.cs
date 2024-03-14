using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task AddDiagnosisToMedicalRecord(AddDiagnosisRequestDto request, int medicalRecordId)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            if (medicalRecord is null)
            {
                throw new MedicalRecordNotFoundException();
            }
            
            var diagnosis = new Diagnosis
            {
                Name = request.Name,
                Description = request.Description,
                Illness = new Illness
                {
                    Name = request.IllnessName
                }
            };

            medicalRecord.Diagnoses.Add(diagnosis);
            await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
        }
    }
}
