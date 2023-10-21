﻿namespace LifeLinkAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PrivateMedicalId { get; set; }
        public PrivateMedical PrivateMedical { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
