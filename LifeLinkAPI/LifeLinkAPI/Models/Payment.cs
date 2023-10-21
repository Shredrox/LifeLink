namespace LifeLinkAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        //public int PrivateMedicalId { get; set; }
        //public PrivateMedical PrivateMedical { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
