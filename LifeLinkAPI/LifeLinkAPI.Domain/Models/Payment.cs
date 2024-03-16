﻿namespace LifeLinkAPI.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Paid { get; set; }
    }
}
