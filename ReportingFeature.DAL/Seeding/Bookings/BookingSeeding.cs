using Microsoft.EntityFrameworkCore;
using ReportingFeature.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.Bookings
{
    public static class BookingSeeding
    {
        public static void BookingSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    BookingId = 1,
                    ClientId =1,
                    BranchId = 1,
                    BookingDate = new DateTime(2024,8,6),
                    BookingTime = new TimeSpan(12,0,0),
                    Status = "Confirmed"
                },
                new Booking()
                {
                    BookingId = 2,
                    ClientId = 2,
                    BranchId = 2,
                    BookingDate = new DateTime(2024, 7, 1),
                    BookingTime = new TimeSpan(11, 0, 0),
                    Status = "Confirmed"
                },
                new Booking()
                {
                    BookingId = 3,
                    ClientId = 3,
                    BranchId = 1,
                    BookingDate = new DateTime(2024, 7, 10),
                    BookingTime = new TimeSpan(8, 0, 0),
                    Status = "Confirmed"
                },
                new Booking()
                {
                    BookingId = 4,
                    ClientId = 4,
                    BranchId = 1,
                    BookingDate = new DateTime(2024, 5, 6),
                    BookingTime = new TimeSpan(10, 0, 0),
                    Status = "Confirmed"
                }
                );
        }
    }
}
