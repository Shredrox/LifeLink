using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class DiagnosisRepository : IDiagnosisRepository
{
    private readonly LifeLinkDbContext _context;

    public DiagnosisRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task InsertDiagnosis(Diagnosis diagnosis)
    {
        _context.Diagnoses.Add(diagnosis);
        await _context.SaveChangesAsync();
    }
}