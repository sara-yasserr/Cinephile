using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinephileProject.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int BookingId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string TransactionId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } 

        // Navigation property
        public virtual Booking Booking { get; set; }
    }

}
