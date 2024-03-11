using LifeLinkAPI.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Infrastructure.Data
{
    public class LifeLinkDbContext : IdentityDbContext<User>
    {
        public LifeLinkDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
