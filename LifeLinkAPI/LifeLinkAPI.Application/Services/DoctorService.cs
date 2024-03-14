using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAppointmentHourRepository _appointmentHourRepository;

    public DoctorService(
        IDoctorRepository doctorRepository, 
        IUserRepository userRepository, 
        IAppointmentHourRepository appointmentHourRepository)
    {
        _doctorRepository = doctorRepository;
        _userRepository = userRepository;
        _appointmentHourRepository = appointmentHourRepository;
    }

    public async Task RegisterDoctor(RegisterDoctorRequestDto request)
    {
        var user = new User
        {
            UserName = request.Username,
            Email = request.Email,
            Role = Role.Doctor
        };

        await _userRepository.InsertUser(user, request.Password);

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
        
        await _doctorRepository.InsertDoctor(doctor);

        foreach (var hour in request.AppointmentHours.Split(','))
        {
            var appointmentHour = new AppointmentHour
            {
                Time = TimeSpan.Parse(hour),
                Schedule = doctor.Schedule
            };

            await _appointmentHourRepository.InsertAppointmentHour(appointmentHour);
        }
    }
}