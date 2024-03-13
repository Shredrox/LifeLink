using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly LifeLinkDbContext _context;

    public DoctorRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<Doctor?> GetDoctorById(int id)
    {
        return await _context.Doctors
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}