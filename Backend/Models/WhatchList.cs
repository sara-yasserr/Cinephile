using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetterboxdProject.AccountDTOs;

namespace LetterboxdProject.Models
{
    public class Watchlist
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
