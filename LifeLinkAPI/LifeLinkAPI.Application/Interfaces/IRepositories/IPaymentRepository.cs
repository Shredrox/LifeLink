using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Interfaces.IRepositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetPaymentsByPatientId(int patientId);
    Task<IEnumerable<Payment>> GetPaymentsByDoctorId(int doctorId);
    Task InsertPayment(Payment payment);
}