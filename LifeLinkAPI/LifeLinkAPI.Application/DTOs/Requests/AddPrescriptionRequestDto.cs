namespace LifeLinkAPI.Application.DTOs.Requests;

public record AddPrescriptionRequestDto(
    string Quantity,
    string MedicationName,
    string MedicationDescription);