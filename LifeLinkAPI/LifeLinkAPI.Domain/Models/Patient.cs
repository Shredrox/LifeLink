namespace LifeLinkAPI.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string SSN { get; set; }
        public required string PhoneNumber { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public User User { get; set; }

        public Patient()
        {
            Payments = new List<Payment>();
        }
    }
}
