namespace LifeLinkAPI.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CEO CEO { get; set; }
        public List<Department> Departments { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
