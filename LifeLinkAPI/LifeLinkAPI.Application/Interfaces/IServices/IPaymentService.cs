using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface IPaymentService
{
    Task<PaymentsResponseDto> GetPaymentsByPatientId(int patientId);
    Task<PaymentsResponseDto> GetPaymentsByDoctorId(int doctorId);
    Task CreatePayment(AddPaymentRequestDto request, int doctorId, int patientId);
}