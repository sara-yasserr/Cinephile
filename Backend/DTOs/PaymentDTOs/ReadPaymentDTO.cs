using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinephileProject.Models;

namespace CinephileProject.DTOs.PaymentDTOs
{
    public class ReadPaymentDTO
    {
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string TransactionId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; }
    }
}
