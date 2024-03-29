﻿namespace SunflowersBookingSystem.Services.Models.Users
{
    public class RegisterRequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
    }
}

