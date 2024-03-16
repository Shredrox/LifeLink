namespace LifeLinkAPI.Application.DTOs.Requests;

public record AddPaymentRequestDto(
    decimal Amount,
    string PaymentMethod);