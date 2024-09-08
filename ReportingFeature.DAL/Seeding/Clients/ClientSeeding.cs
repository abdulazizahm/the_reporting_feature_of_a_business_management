using ReportingFeature.DAL.Models;
using ReportingFeature.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL.Seeding.Clients
{
    public static class ClientSeeding
    {
        public static void ClientSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client() 
                {
                    ClientId =1,
                    Country = "Egypt",
                    Email ="Abdelazizahmed@gmail.com",
                    City = "Assuit",
                    Birthdate =new DateTime(1997,11,1),
                    Address ="Assuit Egypt",
                    Gender = "Male",
                    FirstName="Abdelaziz",
                    LastName="Ahmed",
                    Phone="01000592507"
                },
                new Client()
                     {
                         ClientId = 2,
                         Country = "Egypt",
                         Email = "KhaledMohamed@gmail.com",
                         City = "Cairo",
                         Birthdate = new DateTime(1996, 10, 11),
                         Address = "Cairo Egypt",
                         Gender = "Male",
                         FirstName = "Khaled",
                         LastName = "Mohamed",
                         Phone = "01200592507"
                     },
                new Client()
                          {
                              ClientId = 3,
                              Country = "Egypt",
                              Email = "TarekHassen@gmail.com",
                              City = "Alex",
                              Birthdate = new DateTime(1995, 12, 5),
                              Address = "Alex Egypt",
                              Gender = "Male",
                              FirstName = "Tarek",
                              LastName = "Hassen",
                              Phone = "01100592507"
                          },
                new Client()
                {
                     ClientId = 4,
                     Country = "Egypt",
                     Email = "MidoMoahmed@gmail.com",
                     City = "Cairo",
                     Birthdate = new DateTime(1993, 8, 1),
                     Address = "Cairo Egypt",
                     Gender = "Male",
                     FirstName = "Mido",
                     LastName = "Moahmed",
                     Phone = "01110592500"
                 }
                );
        }
     
    }
}
