namespace SunflowersBookingSystem.Services.Models.Users
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
