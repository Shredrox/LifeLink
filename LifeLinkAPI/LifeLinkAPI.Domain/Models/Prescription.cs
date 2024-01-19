namespace LifeLinkAPI.Domain.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Quantity { get; set; }
        public Medication Medication { get; set; }
    }
}
