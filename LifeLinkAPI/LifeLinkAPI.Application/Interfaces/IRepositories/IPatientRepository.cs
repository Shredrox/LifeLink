using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IPatientRepository
{
    Task Add(Patient patient);
    Task<Patient?> GetPatientById(int id);
}