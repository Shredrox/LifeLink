using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLinkAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<ILabTestService, LabTestService>();
        
        return services;
    }
}