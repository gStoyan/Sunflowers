namespace SunflowersBookingSystem.Services.Models.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Token { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? ProfilePicture { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new List<ReservationDto>();

    }
}
