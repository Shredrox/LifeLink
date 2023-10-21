using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LifeLinkAPI.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public string Diagnosis {  get; set; }
        public string Treatment { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<LabTest> LabTests { get; set; }
        public List<Prescription> Prescriptions { get; set;}
    }
}
