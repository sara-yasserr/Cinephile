namespace LetterboxdProject.DTOs.FilmDTOs
{
    public class FilmDTO
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Director { get; set; }
        public int? Runtime { get; set; }
        public string BackgroundPath { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
    }
}
