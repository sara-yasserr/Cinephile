using System.ComponentModel.DataAnnotations;
using CinephileProject.Models;

namespace CinephileProject.DTOs.SeatDTOs
{
    public class AddSeatDTO
    {
        public int ScreenId { get; set; }
        [Required]
        [StringLength(1)]
        public string Row { get; set; } // A, B, C, etc.

        [Required]
        public int Number { get; set; } // 1, 2, 3, etc.
        public string Type { get; set; } = "Standard";
    }
}
