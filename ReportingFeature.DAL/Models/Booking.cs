using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public int BranchId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Status { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<BookingService> BookingServices { get; set; }
    }
}
