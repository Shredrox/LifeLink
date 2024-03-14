using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class AppointmentHourRepository : IAppointmentHourRepository
{
    private readonly LifeLinkDbContext _context;

    public AppointmentHourRepository(LifeLinkDbContext context)
    {
        _context = context;
    }
    
    public async Task<AppointmentHour?> GetAppointmentHourById(int id)
    {
        return await _context.AppointmentHours.FindAsync(id);
    }

    public async Task<IEnumerable<AppointmentHour>> GetAppointmentHoursByDoctor(int doctorId)
    {
        return await _context.AppointmentHours
            .Where(a => a.Schedule.Doctor.Id == doctorId)
            .ToListAsync();
    }
    
    public async Task InsertAppointmentHour(AppointmentHour appointmentHour)
    {
        _context.AppointmentHours.Add(appointmentHour);
        await _context.SaveChangesAsync();
    }
}