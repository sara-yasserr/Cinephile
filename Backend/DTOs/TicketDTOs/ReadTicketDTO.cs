using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinephileProject.Models;

namespace CinephileProject.DTOs.TicketDTOs
{
    public class ReadTicketDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ticketPrice { get; set; }
        public DateTime IssueDate { get; set; }

        //[Required]
        //public string Barcode { get; set; } 

        //[Required]
        //public int BookingId { get; set; }

        //[Required]
        //public int ShowtimeId { get; set; }

        //[Required]
        //public int SeatId { get; set; }
        //public DateTime startTime { get; set; }
        //public string SeatRow { get; set; }
        //public int SeatNum { get; set; }
        //public string SeatType { get; set; }
        //public string ScreenType { get; set; }
    }
}
