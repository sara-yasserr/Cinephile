using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinephileProject.Models;

namespace CinephileProject.DTOs.PaymentDTOs
{
    public class AddPaymentDTO
    {
        [Required]
        public int BookingId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string TransactionId { get; set; }
    }
}
