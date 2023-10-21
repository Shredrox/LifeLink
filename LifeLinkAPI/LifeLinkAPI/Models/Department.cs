namespace LifeLinkAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
