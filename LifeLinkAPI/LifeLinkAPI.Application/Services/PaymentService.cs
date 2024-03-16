using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public PaymentService(
        IPaymentRepository paymentRepository, 
        IDoctorRepository doctorRepository, 
        IPatientRepository patientRepository)
    {
        _paymentRepository = paymentRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<PaymentsResponseDto> GetPaymentsByPatientId(int patientId)
    {
        var payments = await _paymentRepository.GetPaymentsByPatientId(patientId);

        return new PaymentsResponseDto(payments
            .Select(p => new PaymentDto(p.Amount, p.PaymentMethod, p.Paid))
            .ToList()
        );
    }

    public async Task<PaymentsResponseDto> GetPaymentsByDoctorId(int doctorId)
    {
        var payments = await _paymentRepository.GetPaymentsByDoctorId(doctorId);

        return new PaymentsResponseDto(payments
            .Select(p => new PaymentDto(p.Amount, p.PaymentMethod, p.Paid))
            .ToList()
        );
    }

    public async Task CreatePayment(AddPaymentRequestDto request, int doctorId, int patientId)
    {
        var doctor = await _doctorRepository.GetDoctorById(doctorId);
        var patient = await _patientRepository.GetPatientById(patientId);

        var payment = new Payment
        {
            Doctor = doctor,
            Patient = patient,
            Amount = request.Amount,
            PaymentMethod = request.PaymentMethod,
            Paid = false
        };

        await _paymentRepository.InsertPayment(payment);
    }
}