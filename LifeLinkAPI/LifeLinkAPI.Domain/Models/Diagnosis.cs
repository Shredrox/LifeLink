namespace LifeLinkAPI.Domain.Models
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int IllnessId { get; set; }
        public Illness Illness { get; set; }
    }
}
