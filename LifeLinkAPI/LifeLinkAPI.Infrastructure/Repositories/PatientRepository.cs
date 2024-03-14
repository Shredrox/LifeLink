using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly LifeLinkDbContext _context;

    public PatientRepository(LifeLinkDbContext context)
    {
        _context = context;
    }
    
    public async Task<Patient?> GetPatientById(int id)
    {
        return await _context.Patients.FindAsync(id);
    }
    
    public async Task InsertPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }
}