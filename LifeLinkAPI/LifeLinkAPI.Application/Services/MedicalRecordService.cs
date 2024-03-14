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
        private readonly IDoctorRepository _doctorRepository;

        public MedicalRecordService(
            IMedicalRecordRepository medicalRecordRepository, 
            IDoctorRepository doctorRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task AddDiagnosisToMedicalRecord(AddDiagnosisRequestDto request, int medicalRecordId, int doctorId)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            if (medicalRecord is null)
            {
                throw new MedicalRecordNotFoundException();
            }
            
            var doctor = await _doctorRepository.GetDoctorById(doctorId);
            if (doctor is null)
            {
                throw new DoctorNotFoundException();
            }
            
            var diagnosis = new Diagnosis
            {
                Name = request.Name,
                Description = request.Description,
                Doctor = doctor,
                Illness = new Illness
                {
                    Name = request.IllnessName
                }
            };
            
            medicalRecord.Diagnoses.Add(diagnosis);
            await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
        }

        public async Task AddPrescriptionToMedicalRecord(AddPrescriptionRequestDto request, int medicalRecordId, int doctorId)
        {
            var medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
            if (medicalRecord is null)
            {
                throw new MedicalRecordNotFoundException();
            }

            var doctor = await _doctorRepository.GetDoctorById(doctorId);
            if (doctor is null)
            {
                throw new DoctorNotFoundException();
            }
            
            var prescription = new Prescription
            {
                Date = DateTime.UtcNow,
                Quantity = request.Quantity,
                Doctor = doctor,
                Medication = new Medication
                {
                    Name = request.MedicationName,
                    Description = request.MedicationDescription
                }
            };
            
            medicalRecord.Prescriptions.Add(prescription);
            await _medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
        }
    }
}
