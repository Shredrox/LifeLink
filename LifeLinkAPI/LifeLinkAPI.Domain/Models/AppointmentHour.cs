﻿namespace LifeLinkAPI.Domain.Models;

public class AppointmentHour
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}