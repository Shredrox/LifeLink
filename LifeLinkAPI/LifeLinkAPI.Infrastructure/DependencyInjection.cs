using LifeLinkAPI.Application.Interfaces.IRepositories;
using LifeLinkAPI.Application.Interfaces.IServices;
using LifeLinkAPI.Application.Services;
using LifeLinkAPI.Domain.Models;
using LifeLinkAPI.Infrastructure.Data;
using LifeLinkAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeLinkAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LifeLinkDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("LifeLinkDb")));
        
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<LifeLinkDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMedicalDataService, MedicalDataService>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        
        return services;
    }
}