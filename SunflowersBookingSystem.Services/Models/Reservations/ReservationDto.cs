namespace SunflowersBookingSystem.Services.Models.Reservations
{
    using System;

    public class ReservationDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ArriveTime { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}
