﻿namespace LifeLinkAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenValidity { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        HospitalAdmin,
        Patient,
        Doctor,
        PrivateMedical
    }
}
