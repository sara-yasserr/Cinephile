using LetterboxdProject.AccountDTOs;

namespace LetterboxdProject.Models
{
    public class Watched
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public DateTime WatchDate { get; set; }
    }
}
