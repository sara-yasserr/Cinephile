using System.ComponentModel.DataAnnotations;

namespace CinephileProject.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public int AvailableSeats { get; set; }

        // Navigation properties
        public virtual Movie Movie { get; set; }
        public virtual Screen Screen { get; set; }
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
