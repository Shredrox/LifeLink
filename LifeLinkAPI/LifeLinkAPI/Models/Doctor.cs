namespace LifeLinkAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Experience { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public List<Patient> Patients { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Schedule Schedule { get; set; }
        public List<Payment> Payments { get; set; }
        public User User { get; set; }
    }
}
