using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Models
{
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(BookingId))]
        public Booking Booking { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
    }
}
