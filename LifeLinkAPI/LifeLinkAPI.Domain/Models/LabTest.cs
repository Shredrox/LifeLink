using LifeLinkAPI.Domain.Enums;

namespace LifeLinkAPI.Domain.Models
{
    public class LabTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Result { get; set; }
        public LabTestResultStatus ResultStatus { get; set; }
        public string Cost { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
