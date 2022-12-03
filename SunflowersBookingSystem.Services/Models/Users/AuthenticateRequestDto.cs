namespace SunflowersBookingSystem.Services.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticateRequestDto
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
