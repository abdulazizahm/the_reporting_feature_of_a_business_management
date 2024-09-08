using Microsoft.EntityFrameworkCore;
using ReportingFeature.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.BookingServices
{
    public static class BookingServiceSeeding
    {
        public static void BookingServiceSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingService>().HasData(
                new BookingService()
                {
                    BookingServiceId = 1,
                    BookingId = 1,
                    ServiceId = 4,
                    Price = 20000
                },
                 new BookingService()
                 {
                     BookingServiceId = 2,
                     BookingId = 1,
                     ServiceId = 3,
                     Price = 8000
                 },
                    new BookingService()
                    {
                        BookingServiceId = 3,
                        BookingId = 2,
                        ServiceId = 3,
                        Price = 8000
                    },
                     new BookingService()
                     {
                         BookingServiceId = 4,
                         BookingId = 2,
                         ServiceId = 2,
                         Price = 10000
                     },
                     new BookingService()
                     {
                            BookingServiceId = 5,
                            BookingId = 3,
                            ServiceId = 1,
                            Price = 5000
                     },
                      new BookingService()
                      {
                          BookingServiceId = 6,
                          BookingId = 3,
                          ServiceId = 3,
                          Price = 8000
                      },
                      new BookingService()
                      {
                          BookingServiceId = 7,
                          BookingId = 4,
                          ServiceId = 1,
                          Price = 20000
                      },
                      new BookingService()
                      {
                          BookingServiceId = 8,
                          BookingId = 4,
                          ServiceId = 2,
                          Price = 10000
                      }
                );
        }
    }
}
