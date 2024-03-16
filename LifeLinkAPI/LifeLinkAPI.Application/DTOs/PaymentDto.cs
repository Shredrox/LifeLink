namespace LifeLinkAPI.Application.DTOs;

public record PaymentDto(
    decimal Amount,
    string PaymentMethod,
    bool Paid);