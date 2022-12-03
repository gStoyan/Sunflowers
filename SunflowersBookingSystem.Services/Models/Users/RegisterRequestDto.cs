namespace SunflowersBookingSystem.Services.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

