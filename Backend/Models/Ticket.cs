using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinephileProject.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        //[Required]
        //public int BookingId { get; set; }

        //[Required]
        //public int ShowtimeId { get; set; }

        //[Required]
        //public int SeatId { get; set; }

        //public virtual Booking Booking { get; set; }
        //public virtual Showtime Showtime { get; set; }
        //public virtual Seat Seat { get; set; }
    }
}
