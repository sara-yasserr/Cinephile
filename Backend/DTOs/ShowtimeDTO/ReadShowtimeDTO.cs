using System.ComponentModel.DataAnnotations;
using CinephileProject.Models;

namespace CinephileProject.DTOs.ShowtimeDTO
{
    public class ReadShowtimeDTO
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string ScreenType { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public int AvailableSeats { get; set; }
    }
}
