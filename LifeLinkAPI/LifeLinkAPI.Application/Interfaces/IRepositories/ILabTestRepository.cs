using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface ILabTestRepository
{
    Task<LabTest?> GetLabTestById(int id);
    Task<IEnumerable<LabTest>> GetLabTestsByMedicalRecordId(int medicalRecordId);
    Task InsertLabTest(LabTest labTest);
    Task UpdateLabTest(LabTest labTest);
}