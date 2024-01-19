namespace LifeLinkAPI.Domain.Models
{
    public class LabTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public string Cost { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
