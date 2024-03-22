using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Exceptions;
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
    
    public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAndDate(int doctorId, DateTime date)
    {
        return await _context.Appointments
            .Where(a => a.Date.ToLocalTime().Date == date.Date && a.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<Appointment?> GetAppointmentsById(int appointmentId)
    {
        return await _context.Appointments.FindAsync(appointmentId);
    }

    public async Task InsertAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        _context.Entry(appointment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        var appointment = await _context.Appointments.FindAsync(appointmentId);
        
        if (appointment is null)
        {
            throw new AppointmentNotFountException();
        }
        
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
    }
}