using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Enums;
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

    public async Task<LabTestResponseDto> GetLabTestsByMedicalRecordId(int medicalRecordId)
    {
        var labTests = await _labTestRepository.GetLabTestsByMedicalRecordId(medicalRecordId);

        return new LabTestResponseDto(labTests
            .Select(l => new LabTestDto(l.Name, l.Result, l.Cost))
            .ToList()
        );
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
            ResultStatus = LabTestResultStatus.Pending,
            Cost = request.Cost,
            MedicalRecord = medicalRecord
        };

        await _labTestRepository.InsertLabTest(labTest);
    }

    public async Task AddLabTestResult(AddLabTestResultRequestDto request, int labTestId)
    {
        var labTest = await _labTestRepository.GetLabTestById(labTestId);

        if (labTest is null)
        {
            throw new LabTestNotFoundException();
        }
        
        labTest.Result = request.Result;
        labTest.ResultStatus = LabTestResultStatus.Available;

        await _labTestRepository.UpdateLabTest(labTest);
    }
}