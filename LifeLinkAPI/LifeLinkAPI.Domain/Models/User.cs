using Microsoft.AspNetCore.Identity;

namespace LifeLinkAPI.Domain.Models
{
    public class User : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenValidity { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        ClinicManager,
        Doctor,
        Patient
    }
}
