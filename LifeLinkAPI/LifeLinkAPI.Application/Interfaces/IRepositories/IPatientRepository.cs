using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IPatientRepository
{
    Task<Patient?> GetPatientById(int id);
    Task InsertPatient(Patient patient);
}