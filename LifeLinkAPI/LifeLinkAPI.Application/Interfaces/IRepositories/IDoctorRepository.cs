using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IDoctorRepository
{
    Task<Doctor?> GetDoctorById(int id);
    Task InsertDoctor(Doctor doctor);
}