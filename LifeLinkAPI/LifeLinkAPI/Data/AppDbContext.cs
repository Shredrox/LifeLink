using LifeLinkAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeLinkAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PrivateMedical> PrivateMedicals { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CEO> Ceos { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<HospitalStay> HospitalStays { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
