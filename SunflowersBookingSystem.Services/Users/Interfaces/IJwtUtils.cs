namespace SunflowersBookingSystem.Services.Users.Interfaces
{
    using SunflowersBookingSystem.Data.Models;
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
