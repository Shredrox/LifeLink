using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IDiagnosisRepository
{
    Task InsertDiagnosis(Diagnosis diagnosis);
}