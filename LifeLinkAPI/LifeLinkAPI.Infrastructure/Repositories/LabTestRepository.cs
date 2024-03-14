using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class LabTestRepository : ILabTestRepository
{
    private readonly LifeLinkDbContext _context;

    public LabTestRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task InsertLabTest(LabTest labTest)
    {
        _context.LabTests.Add(labTest);
        await _context.SaveChangesAsync();
    }
}