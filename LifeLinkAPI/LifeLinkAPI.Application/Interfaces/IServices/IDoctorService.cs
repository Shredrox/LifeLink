using LifeLinkAPI.Application.DTOs.Requests;

namespace LifeLinkAPI.Application.Interfaces.IServices;

public interface IDoctorService
{
    Task RegisterDoctor(RegisterDoctorRequestDto request);
}