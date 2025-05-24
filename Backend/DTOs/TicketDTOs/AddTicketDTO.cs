using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinephileProject.DTOs.TicketDTOs
{
    public class AddTicketDTO
    {
        [Required]
        public string Type { get; set; }

        //[Required]
        //public int BookingId { get; set; }

        //[Required]
        //public int ShowtimeId { get; set; }

        //[Required]
        //public int SeatId { get; set; }
        public decimal? price { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    }
}
