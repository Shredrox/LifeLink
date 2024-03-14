using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly LifeLinkDbContext _context;

    public MedicalRecordRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task<MedicalRecord?> GetMedicalRecordById(int id)
    {
        return await _context.MedicalRecords.FindAsync(id);
    }

    public async Task UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        _context.Entry(medicalRecord).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}