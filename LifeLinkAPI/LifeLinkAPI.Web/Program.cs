using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LifeLinkAPI.Application;
using LifeLinkAPI.Infrastructure;
using LifeLinkAPI.Infrastructure.Hubs;
using LifeLinkAPI.Middlewares;

namespace LifeLinkAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
                  options.AddPolicy("AllowOrigin", policy =>
                  {
                      policy.WithOrigins(
                                "http://127.0.0.1:5173",
                                "http://127.0.0.1:5173/",
                                "http://localhost:5173",
                                "http://localhost:5173/",
                                "http://localhost")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                  })
                );

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.RequireHttpsMetadata = false;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the best token ever aaaaaaahertjetjaetja")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };

                jwt.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.ContainsKey("AccessToken"))
                        {
                            context.Token = context.Request.Cookies["AccessToken"];
                        }

                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            
            app.MapControllers();
            
            app.MapHub<ChatHub>("/chat");

            app.Run();
        }
    }
}