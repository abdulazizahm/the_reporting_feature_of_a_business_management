using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReportingFeature.DAL.Seeding.Clients;
using ReportingFeature.DAL.Seeding.Branches;
using ReportingFeature.DAL.Seeding.Services;
using ReportingFeature.DAL.Seeding.Bookings;
using ReportingFeature.DAL.Seeding.BookingServices;
using ReportingFeature.DAL.Seeding.Transactions;
using Microsoft.AspNetCore.Identity;



namespace ReportingFeature.DAL.Models
{
    public class RFContext :DbContext, IDisposable
    {
        private readonly IConfiguration configuration;
        public RFContext()
        {

        }
        public RFContext(DbContextOptions<RFContext> options, IConfiguration configuration)
          : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }



        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
           .HasMany(b => b.BookingServices)
           .WithOne(bs => bs.Booking)
           .HasForeignKey(bs => bs.BookingId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Client)
                .WithMany(d=>d.Bookings)
                .HasForeignKey(b => b.ClientId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Branch)
                .WithMany()
                .HasForeignKey(b => b.BranchId);

        
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Booking)
                .WithMany(d=>d.Transactions)
                .HasForeignKey(t => t.BookingId);

            //modelBuilder.GeneralSettingSeed();

            modelBuilder.ClientSeed();
            modelBuilder.BranchSeed();
            modelBuilder.ServiceSeed();
            modelBuilder.BookingSeed();
            modelBuilder.BookingServiceSeed();
            modelBuilder.TransactionSeeded();

            base.OnModelCreating(modelBuilder);
        }



        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}
