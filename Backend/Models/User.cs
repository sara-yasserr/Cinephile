using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LetterboxdProject.Models;

namespace LetterboxdProject.AccountDTOs
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
        [JsonIgnore]
        public virtual List<Watchlist> Watchlist { get; set; }
        [JsonIgnore]
        public virtual List<Watched> WatchedFilms { get; set; }
        [JsonIgnore]
        public virtual List<Rating> Ratings { get; set; }
    }
}
