namespace SunflowersBookingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Identity;

    public class User
    {

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }


        [Column("FirstName")]
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Column("SecondName")]
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string SecondName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
