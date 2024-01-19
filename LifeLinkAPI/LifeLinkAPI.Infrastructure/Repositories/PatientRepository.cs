using LifeLinkAPI.Application.Interfaces.Repositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }
}