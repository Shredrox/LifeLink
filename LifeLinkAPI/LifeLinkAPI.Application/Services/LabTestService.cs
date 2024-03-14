using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Exceptions;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class LabTestService : ILabTestService
{
    private readonly ILabTestRepository _labTestRepository;
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public LabTestService(
        ILabTestRepository labTestRepository, 
        IMedicalRecordRepository medicalRecordRepository)
    {
        _labTestRepository = labTestRepository;
        _medicalRecordRepository = medicalRecordRepository;
    }

    public async Task AddLabTest(AddLabTestRequestDto request, int medicalRecordId)
    {
        var medicalRecord = await _medicalRecordRepository.GetMedicalRecordById(medicalRecordId);
        if (medicalRecord is null)
        {
            throw new MedicalRecordNotFoundException();
        }

        var labTest = new LabTest
        {
            Name = request.Name,
            Result = request.Result,
            Cost = request.Cost,
            MedicalRecord = medicalRecord
        };

        await _labTestRepository.InsertLabTest(labTest);
    }
}