using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.Repositories;

public interface IPatientRepository
{
    Task Add(Patient patient);
}