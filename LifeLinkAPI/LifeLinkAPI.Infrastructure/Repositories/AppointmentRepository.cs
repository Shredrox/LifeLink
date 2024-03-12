using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly LifeLinkDbContext _context;

    public AppointmentRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task CreateAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetAllAppointmentsByDoctorAndDate(int doctorId, DateTime date)
    {
        return await _context.Appointments
            .Where(a => a.Date == date && a.DoctorId == doctorId)
            .ToListAsync();
    }
}