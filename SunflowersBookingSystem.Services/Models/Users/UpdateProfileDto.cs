namespace SunflowersBookingSystem.Services.Models.Users
{
    public class UpdateProfileDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
