using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinephileProject.Models;

namespace CinephileProject.DTOs.BookingDTOs
{
    public class ReadBookingDTO
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int ShowtimeId { get; set; }
        public DateTime BookingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        //public BookingStatus Status { get; set; } 
        public string user_Name { get; set; }
        public DateTime showtime_Time { get; set; }
        //public string payment_Method { get; set; }
    }
}
