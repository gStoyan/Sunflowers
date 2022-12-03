﻿namespace SunflowersBookingSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using SunflowersBookingSystem.Services.Models.Users;

    public class AuthenticateViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Password { get; set; }

        public AuthenticateRequestDto ConvertToDto() =>
            new AuthenticateRequestDto
            {
                FirstName = FirstName,
                Password = Password,
            };
    }
}
