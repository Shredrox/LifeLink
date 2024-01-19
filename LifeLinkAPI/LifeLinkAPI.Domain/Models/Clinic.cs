namespace LifeLinkAPI.Domain.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ClinicManager ClinicManager { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
