using System.ComponentModel.DataAnnotations;
using SunflowersBookingSystem.Services.Models.Users;

namespace SunflowersBookingSystem.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Country { get; set; }

        public RegisterRequestDto ConvertToDto() =>
            new RegisterRequestDto()
            {
                Email = Email,
                FirstName = FirstName,
                SecondName = SecondName,
                PasswordHash = Password,
                Phone = Phone,
                Country = Country
            };
    }
}
