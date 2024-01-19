namespace LifeLinkAPI.Domain.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set;}
    }
}
