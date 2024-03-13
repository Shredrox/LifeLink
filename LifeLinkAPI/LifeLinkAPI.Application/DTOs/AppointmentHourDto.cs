namespace LifeLinkAPI.Application.DTOs;

public class AppointmentHourDto
{
    public TimeSpan Time { get; set; }
    public bool Booked { get; set; }
}