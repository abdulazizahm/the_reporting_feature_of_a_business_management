using Microsoft.EntityFrameworkCore;
using ReportingFeature.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.Services
{
    public static class ServiceSeeding
    {
        public static void ServiceSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service() 
                {
                    ServiceId = 1 ,
                    Name ="Game Device",
                    Description= "Game Device per day Service Introduce For Client",
                    Duration=1,
                    Price=5000
                },
                 new Service()
                 {
                     ServiceId = 2,
                     Name = "Pool",
                     Description = "Pool Service per day Introduce For Client",
                     Duration = 1,
                     Price = 10000
                 },
                 new Service()
                 {
                     ServiceId = 3,
                     Name = "Gym",
                     Description = "Gym Service per day Introduce For Client",
                     Duration = 1,
                     Price = 8000
                 },
                  new Service()
                  {
                      ServiceId = 4,
                      Name = "Food",
                      Description = "Food Service per week Introduce For Client",
                      Duration = 7,
                      Price = 20000
                  }
                );
        }
    }
}
