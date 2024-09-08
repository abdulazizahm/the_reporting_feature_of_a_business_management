using Microsoft.EntityFrameworkCore;
using ReportingFeature.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.Branches
{
    public static class BranchSeeding
    {
        public static void BranchSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(
                new Branch()
                {
                    BranchId = 1,
                    Country = "Egypt",
                    City = "Assuit",
                    Address = "Assuit Egypt",
                    Phone = "01000000007",
                    Name="Branch One"
                },
                 new Branch()
                 {
                     BranchId = 2,
                     Country = "Egypt",
                     City = "Cairo",
                     Address = "Cairo Egypt",
                     Phone = "01000000003",
                     Name = "Branch Two"
                 },
                 new Branch()
                 {
                     BranchId = 3,
                     Country = "Egypt",
                     City = "Alex",
                     Address = "Alex Egypt",
                     Phone = "01000000003",
                     Name = "Branch Three"
                 }
                );
        }
    }
}
