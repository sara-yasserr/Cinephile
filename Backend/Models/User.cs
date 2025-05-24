using System.ComponentModel.DataAnnotations;

namespace CinephileProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [StringLength(20)]
        public string Role { get; set; } = "User";

        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
