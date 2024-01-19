namespace LifeLinkAPI.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string WorkHours { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
