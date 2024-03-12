using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUserRepository _userRepository;

    public DoctorService(
        IDoctorRepository doctorRepository, 
        IUserRepository userRepository)
    {
        _doctorRepository = doctorRepository;
        _userRepository = userRepository;
    }

    public async Task RegisterDoctor(RegisterDoctorRequestDto request)
    {
        var user = new User
        {
            UserName = request.Username,
            Email = request.Email,
            Role = Role.Doctor
        };

        await _userRepository.Add(user, request.Password);

        var doctor = new Doctor
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Specialty = request.Specialty,
            Experience = request.Experience,
            Age = request.Age,
            Schedule = new Schedule
            {
                WorkHours = request.WorkHours
            },
            User = user
        };
        
        await _doctorRepository.Add(doctor);
    }
}