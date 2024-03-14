using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface ILabTestRepository
{
    Task InsertLabTest(LabTest labTest);
}