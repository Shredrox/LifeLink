namespace LifeLinkAPI.Domain.Models
{
    public class ClinicManager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public User User { get; set; }
    }
}
