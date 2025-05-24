using System.ComponentModel.DataAnnotations;

namespace CinephileProject.DTOs.UserDTOs
{
    public class ReadUserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User";

        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
    }
}
