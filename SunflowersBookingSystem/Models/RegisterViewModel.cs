using System.ComponentModel.DataAnnotations;

namespace SunflowersBookingSystem.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PasswordHash { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
