namespace LifeLinkAPI.Application.DTOs.Responses;

public record PaymentsResponseDto(
    List<PaymentDto> payments);