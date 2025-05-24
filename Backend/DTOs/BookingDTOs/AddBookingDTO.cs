using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinephileProject.DTOs.BookingDTOs
{
    public class AddBookingDTO
    {
        [Required]
        public int TicketId { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ShowtimeId { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    }
}
