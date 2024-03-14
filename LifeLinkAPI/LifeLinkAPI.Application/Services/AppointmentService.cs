using LifeLinkAPI.Application.DTOs;
using LifeLinkAPI.Application.DTOs.Requests;
using LifeLinkAPI.Application.DTOs.Responses;
using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Domain.Models;

namespace LifeLinkAPI.Application.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IAppointmentHourRepository _appointmentHourRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        IAppointmentHourRepository appointmentHourRepository, 
        IDoctorRepository doctorRepository, 
        IPatientRepository patientRepository)
    {
        _appointmentHourRepository = appointmentHourRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
    }
    
    public async Task<AppointmentHoursResponseDto> GetAllAppointmentHoursByDoctorAndDate(int doctorId, DateTime date)
    {
        var appointmentHours = await _appointmentHourRepository.GetAppointmentHoursByDoctor(doctorId);
        var appointments = await _appointmentRepository.GetAppointmentsByDoctorIdAndDate(doctorId, date);
        
        var appointmentHoursDtos = appointmentHours
            .Select(ah => new AppointmentHourDto
            {
                Time = ah.Time,
                Booked = appointments.Any(a => a.AppointmentHour.Time == ah.Time)
            })
            .ToList();
        
        return new AppointmentHoursResponseDto(appointmentHoursDtos);
    }
    
    public async Task CreateAppointment(BookAppointmentRequestDto request)
    {
        var appointmentHour = await _appointmentHourRepository.GetAppointmentHourById(request.AppointmentHourId);
        var doctor = await _doctorRepository.GetDoctorById(request.DoctorId);
        var patient = await _patientRepository.GetPatientById(request.PatientId);

        if (appointmentHour is null || doctor is null || patient is null)
        {
            return;
        }
        
        var appointment = new Appointment
        {
            Doctor = doctor,
            Patient = patient,
            AppointmentHour = appointmentHour,
            Date = request.Date
        };

        await _appointmentRepository.InsertAppointment(appointment);
    }
}