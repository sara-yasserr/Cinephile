using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinephileProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Director { get; set; }
        public int? Runtime { get; set; }
        public string? BackgroundPath { get; set; }
        public string? PosterPath { get; set; }
        public string? Description { get; set; }
        [StringLength(20)]
        [Display(Name = "YouTube Video ID")]
        public string? YouTubeTrailerId { get; set; }
        [NotMapped]
        public string? YouTubeEmbedUrl => !string.IsNullOrEmpty(YouTubeTrailerId)
                ? $"https://www.youtube.com/embed/{YouTubeTrailerId}?autoplay=0&rel=0"
                : null;
        public string? Language { get; set; }
        [JsonIgnore]
        public virtual List<Genre>? Genres { get; set; } = new List<Genre>();
        public virtual List<Showtime>? Showtimes { get; set; } = new List<Showtime>();
    }
}
