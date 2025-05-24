using System.ComponentModel.DataAnnotations;

namespace CinephileProject.DTOs.ShowtimeDTO
{
    public class AddShowtimeDTO
    {
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public int AvailableSeats { get; set; }
    }
}
