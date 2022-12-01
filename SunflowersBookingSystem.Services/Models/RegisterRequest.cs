namespace SunflowersBookingSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

