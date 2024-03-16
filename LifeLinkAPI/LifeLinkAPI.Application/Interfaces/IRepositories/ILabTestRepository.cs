using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface ILabTestRepository
{
    Task<IEnumerable<LabTest>> GetLabTestsByMedicalRecordId(int medicalRecordId);
    Task InsertLabTest(LabTest labTest);
}