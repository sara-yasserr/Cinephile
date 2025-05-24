namespace CinephileProject.DTOs.GenreDTOs
{
    public class ReadGenreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual List<string> Movies { get; set; }
    }
}
