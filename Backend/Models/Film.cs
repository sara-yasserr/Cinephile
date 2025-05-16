using System.Text.Json.Serialization;

namespace LetterboxdProject.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Director { get; set; }
        public int? Runtime { get; set; }
        public string BackgroundPath { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Rating> Ratings { get; set; }
    }
}
