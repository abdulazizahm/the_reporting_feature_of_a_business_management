using Microsoft.EntityFrameworkCore;
using ReportingFeature.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.Transactions
{
    public static class TransactionSeeding
    {
        public static void TransactionSeeded(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction() 
                {
                    TransactionId=1,
                    Amount=28000,
                    BookingId=1,
                    PaymentMethod="Cash",
                    PaymentDate= new DateTime(2024, 8, 14)
                },
                 new Transaction()
                 {
                     TransactionId = 2,
                     Amount = 18000,
                     BookingId = 2,
                     PaymentMethod = "Visa",
                     PaymentDate = new DateTime(2024, 7, 8)
                 },
                  new Transaction()
                  {
                      TransactionId = 3,
                      Amount = 13000,
                      BookingId = 3,
                      PaymentMethod = "Visa",
                      PaymentDate = new DateTime(2024, 7, 17)
                  },
                  new Transaction()
                  {
                      TransactionId = 4,
                      Amount = 30000,
                      BookingId = 4,
                      PaymentMethod = "Visa",
                      PaymentDate = new DateTime(2024, 5, 16)
                  }

                );
        }
    }
}
