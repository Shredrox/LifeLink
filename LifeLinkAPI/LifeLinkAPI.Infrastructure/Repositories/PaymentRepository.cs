using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly LifeLinkDbContext _context;

    public PaymentRepository(LifeLinkDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByPatientId(int patientId)
    {
        return await _context.Payments
            .Where(p => p.PatientId == patientId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Payment>> GetPaymentsByDoctorId(int doctorId)
    {
        return await _context.Payments
            .Where(p => p.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task InsertPayment(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }
}