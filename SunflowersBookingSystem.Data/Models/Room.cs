namespace SunflowersBookingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Room
    {

        [Column("Id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public int Capacity { get; set; }

        public bool Booked { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
