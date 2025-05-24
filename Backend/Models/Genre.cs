using System.Text.Json.Serialization;

namespace CinephileProject.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
