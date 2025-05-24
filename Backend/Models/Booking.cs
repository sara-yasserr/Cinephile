using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinephileProject.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int TicketId { get; set; }
        [Required]
        public int ShowtimeId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal TotalAmount { get; set; }
        //public BookingStatus Status { get; set; } = BookingStatus.Confirmed;
        public virtual User User { get; set; }
        public virtual Showtime Showtime { get; set; }
        public virtual Payment Payment { get; set; }
    }

    //public enum BookingStatus { Pending, Confirmed, Cancelled, Refunded }
}
