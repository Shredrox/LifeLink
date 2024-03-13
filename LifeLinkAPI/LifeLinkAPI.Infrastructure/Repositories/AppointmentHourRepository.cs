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

    public async Task Add(AppointmentHour appointmentHour)
    {
        _context.AppointmentHours.Add(appointmentHour);
        await _context.SaveChangesAsync();
    }

    public async Task<AppointmentHour?> GetAppointmentHourById(int id)
    {
        return await _context.AppointmentHours
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<AppointmentHour>> GetAllAppointmentHoursByDoctor(int doctorId)
    {
        return await _context.AppointmentHours
            .Where(a => a.Schedule.Doctor.Id == doctorId)
            .ToListAsync();
    }
}