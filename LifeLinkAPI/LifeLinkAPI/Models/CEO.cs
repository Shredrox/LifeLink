﻿namespace LifeLinkAPI.Models
{
    public class CEO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}