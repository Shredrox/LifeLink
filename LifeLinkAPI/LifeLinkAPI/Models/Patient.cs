using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LifeLinkAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string SSN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public int? GPId { get; set; }
        public Doctor? GP { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}
