﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReportingFeature.DAL.Models;

#nullable disable

namespace ReportingFeature.DAL.Migrations
{
    [DbContext(typeof(RFContext))]
    [Migration("20240908213801_add-entities-and-seeding-demo-data")]
    partial class addentitiesandseedingdemodata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReportingFeature.DAL.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("BookingTime")
                        .HasColumnType("time");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingId");

                    b.HasIndex("BranchId");

                    b.HasIndex("ClientId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1,
                            BookingDate = new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingTime = new TimeSpan(0, 12, 0, 0, 0),
                            BranchId = 1,
                            ClientId = 1,
                            Status = "Confirmed"
                        },
                        new
                        {
                            BookingId = 2,
                            BookingDate = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingTime = new TimeSpan(0, 11, 0, 0, 0),
                            BranchId = 2,
                            ClientId = 2,
                            Status = "Confirmed"
                        },
                        new
                        {
                            BookingId = 3,
                            BookingDate = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingTime = new TimeSpan(0, 8, 0, 0, 0),
                            BranchId = 1,
                            ClientId = 3,
                            Status = "Confirmed"
                        },
                        new
                        {
                            BookingId = 4,
                            BookingDate = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookingTime = new TimeSpan(0, 10, 0, 0, 0),
                            BranchId = 1,
                            ClientId = 4,
                            Status = "Confirmed"
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.BookingService", b =>
                {
                    b.Property<int>("BookingServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingServiceId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("BookingServiceId");

                    b.HasIndex("BookingId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BookingServices");

                    b.HasData(
                        new
                        {
                            BookingServiceId = 1,
                            BookingId = 1,
                            Price = 20000m,
                            ServiceId = 4
                        },
                        new
                        {
                            BookingServiceId = 2,
                            BookingId = 1,
                            Price = 8000m,
                            ServiceId = 3
                        },
                        new
                        {
                            BookingServiceId = 3,
                            BookingId = 2,
                            Price = 8000m,
                            ServiceId = 3
                        },
                        new
                        {
                            BookingServiceId = 4,
                            BookingId = 2,
                            Price = 10000m,
                            ServiceId = 2
                        },
                        new
                        {
                            BookingServiceId = 5,
                            BookingId = 3,
                            Price = 5000m,
                            ServiceId = 1
                        },
                        new
                        {
                            BookingServiceId = 6,
                            BookingId = 3,
                            Price = 8000m,
                            ServiceId = 3
                        },
                        new
                        {
                            BookingServiceId = 7,
                            BookingId = 4,
                            Price = 20000m,
                            ServiceId = 1
                        },
                        new
                        {
                            BookingServiceId = 8,
                            BookingId = 4,
                            Price = 10000m,
                            ServiceId = 2
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            Address = "Assuit Egypt",
                            City = "Assuit",
                            Country = "Egypt",
                            Name = "Branch One",
                            Phone = "01000000007"
                        },
                        new
                        {
                            BranchId = 2,
                            Address = "Cairo Egypt",
                            City = "Cairo",
                            Country = "Egypt",
                            Name = "Branch Two",
                            Phone = "01000000003"
                        },
                        new
                        {
                            BranchId = 3,
                            Address = "Alex Egypt",
                            City = "Alex",
                            Country = "Egypt",
                            Name = "Branch Three",
                            Phone = "01000000003"
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Address = "Assuit Egypt",
                            Birthdate = new DateTime(1997, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Assuit",
                            Country = "Egypt",
                            Email = "Abdelazizahmed@gmail.com",
                            FirstName = "Abdelaziz",
                            Gender = "Male",
                            LastName = "Ahmed",
                            Phone = "01000592507"
                        },
                        new
                        {
                            ClientId = 2,
                            Address = "Cairo Egypt",
                            Birthdate = new DateTime(1996, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Cairo",
                            Country = "Egypt",
                            Email = "KhaledMohamed@gmail.com",
                            FirstName = "Khaled",
                            Gender = "Male",
                            LastName = "Mohamed",
                            Phone = "01200592507"
                        },
                        new
                        {
                            ClientId = 3,
                            Address = "Alex Egypt",
                            Birthdate = new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Alex",
                            Country = "Egypt",
                            Email = "TarekHassen@gmail.com",
                            FirstName = "Tarek",
                            Gender = "Male",
                            LastName = "Hassen",
                            Phone = "01100592507"
                        },
                        new
                        {
                            ClientId = 4,
                            Address = "Cairo Egypt",
                            Birthdate = new DateTime(1993, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Cairo",
                            Country = "Egypt",
                            Email = "MidoMoahmed@gmail.com",
                            FirstName = "Mido",
                            Gender = "Male",
                            LastName = "Moahmed",
                            Phone = "01110592500"
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Description = "Game Device per day Service Introduce For Client",
                            Duration = 1,
                            Name = "Game Device",
                            Price = 5000m
                        },
                        new
                        {
                            ServiceId = 2,
                            Description = "Pool Service per day Introduce For Client",
                            Duration = 1,
                            Name = "Pool",
                            Price = 10000m
                        },
                        new
                        {
                            ServiceId = 3,
                            Description = "Gym Service per day Introduce For Client",
                            Duration = 1,
                            Name = "Gym",
                            Price = 8000m
                        },
                        new
                        {
                            ServiceId = 4,
                            Description = "Food Service per week Introduce For Client",
                            Duration = 7,
                            Name = "Food",
                            Price = 20000m
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BookingId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            Amount = 28000m,
                            BookingId = 1,
                            PaymentDate = new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Cash"
                        },
                        new
                        {
                            TransactionId = 2,
                            Amount = 18000m,
                            BookingId = 2,
                            PaymentDate = new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Visa"
                        },
                        new
                        {
                            TransactionId = 3,
                            Amount = 13000m,
                            BookingId = 3,
                            PaymentDate = new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Visa"
                        },
                        new
                        {
                            TransactionId = 4,
                            Amount = 30000m,
                            BookingId = 4,
                            PaymentDate = new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = "Visa"
                        });
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Booking", b =>
                {
                    b.HasOne("ReportingFeature.DAL.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReportingFeature.DAL.Models.Client", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.BookingService", b =>
                {
                    b.HasOne("ReportingFeature.DAL.Models.Booking", "Booking")
                        .WithMany("BookingServices")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReportingFeature.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Transaction", b =>
                {
                    b.HasOne("ReportingFeature.DAL.Models.Booking", "Booking")
                        .WithMany("Transactions")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Booking", b =>
                {
                    b.Navigation("BookingServices");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ReportingFeature.DAL.Models.Client", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
