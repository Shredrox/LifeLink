namespace LifeLinkAPI.Domain.Models
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
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public Schedule Schedule { get; set; }
        public User User { get; set; }

        public Doctor()
        {
            Appointments = new List<Appointment>();
            Prescriptions = new List<Prescription>();
        }
    }
}
