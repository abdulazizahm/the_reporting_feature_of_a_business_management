using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReportingFeature.DAL.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        [ForeignKey(nameof(BookingId))]
        public Booking Booking { get; set; }
    }
}
