using CinephileProject.DTOs.ShowtimeDTO;
using CinephileProject.Models;

namespace CinephileProject.DTOs.MovieDTOs
{
    public class AddMovieDTO
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Director { get; set; }
        public int? Runtime { get; set; }
        public string? BackgroundPath { get; set; }
        //public IFormFile? BackgroundFile { get; set; }
        public string? PosterPath { get; set; }
        //public IFormFile? PosterFile { get; set; }
        public string? Description { get; set; }
        public string? YouTubeTrailerId { get; set; }
        public string? Language { get; set; }
        public List<string>? Genres { get; set; }
    }
}
