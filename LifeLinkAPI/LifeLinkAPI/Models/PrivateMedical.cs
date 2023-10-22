namespace LifeLinkAPI.Models
{
    public class PrivateMedical
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string Experience { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Schedule Schedule { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Payment> Payments { get; set; }
        public User User { get; set; }
    }
}
