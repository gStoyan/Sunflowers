namespace SunflowersBookingSystem.Services.Models.Reservations
{
    using System;
    using SunflowersBookingSystem.Services.Models.Users;

    public class ReservationDto
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ArriveTime { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
