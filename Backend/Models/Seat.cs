using System.ComponentModel.DataAnnotations;

namespace CinephileProject.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int ScreenId { get; set; }
        [Required]
        [StringLength(1)]
        public string Row { get; set; } // A, B, C, etc.

        [Required]
        public int Number { get; set; } // 1, 2, 3, etc.
        public string Type { get; set; } = "Standard";
        public virtual Screen Screen { get; set; }
    }
}
