using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IDoctorRepository
{
    Task Add(Doctor doctor);
    Task<Doctor?> GetDoctorById(int id);
}