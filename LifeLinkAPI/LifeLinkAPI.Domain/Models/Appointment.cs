﻿namespace LifeLinkAPI.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime Date { get; set; }
    }
}