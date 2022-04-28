namespace SunflowersBookingSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthenticateRequest
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
