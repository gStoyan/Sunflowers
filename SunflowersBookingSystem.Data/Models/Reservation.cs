namespace SunflowersBookingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reservation
    {
        [Column("Id")]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("Start Date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("End Date")]
        [Required]
        public DateTime EndDate { get; set; }


        [Column("Arrival Time")]
        [Required]
        public DateTime ArriveTime { get; set; }

        [Column("Comment")]
        [MaxLength(245)]
        public string Comment { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
