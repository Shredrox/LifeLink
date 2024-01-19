namespace LifeLinkAPI.Domain.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public required string Gender { get; set; }
        public required string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Diagnosis>? Diagnoses {  get; set; }
        public List<LabTest>? LabTests { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public MedicalRecord()
        {
            RegistrationDate = DateTime.Now.ToUniversalTime();
        }
    }
}
