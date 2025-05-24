namespace CinephileProject.DTOs.MovieDTOs
{
    public class ReadMovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Director { get; set; }
        public int? Runtime { get; set; }
        public string? BackgroundPath { get; set; }
        public string? PosterPath { get; set; }
        public string? Description { get; set; }
        public string? YouTubeTrailerId { get; set; }
        public string? Language { get; set; }
        public List<string>? Genres { get; set; }
        public List<string>? Showtimes { get; set; }

    }
}
