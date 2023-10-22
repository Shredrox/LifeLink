namespace LifeLinkAPI.Models
{
    public class HospitalStay
    {
        public int Id { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public string RoomNumber {  get; set; }
        public string Cost { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
