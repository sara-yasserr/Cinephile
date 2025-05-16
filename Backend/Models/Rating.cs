using LetterboxdProject.AccountDTOs;

namespace LetterboxdProject.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public double RatingValue { get; set; }
        public DateTime RatingDate { get; set; }
        public virtual User User { get; set; }
        public virtual Film Film { get; set; }
    }
}
