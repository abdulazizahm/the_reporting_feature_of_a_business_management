using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReportingFeature.DTO;
using ReportingFeature.DTO.Reports;
using ReportingFeature.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.Business
{
    public class ReportManager : BaseMananger
    {
        public ReportManager(UnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
                
        }

        public async Task<Response> GetRevenueReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod)
        {
            var bookingServicesQuery = _unitOfWork.BookingService.GetAll()
              .Include(d => d.Booking).ThenInclude(d => d.Transactions)
              .Include(d => d.Booking).ThenInclude(d => d.Branch)
              .Include(d => d.Service)
              .Where(d => d.Booking.BookingDate >= startDate && d.Booking.BookingDate <= endDate);

            // Apply filtering conditions
            if (branchId != null)
            {
                bookingServicesQuery = bookingServicesQuery.Where(d => d.Booking.BranchId == branchId);
            }

            if (serviceId != null)
            {
                bookingServicesQuery = bookingServicesQuery.Where(d => d.ServiceId == serviceId);
            }

            if (paymentMethod != null)
            {
                bookingServicesQuery = bookingServicesQuery.Where(d => d.Booking.Transactions.Any(dd=>dd.PaymentMethod == paymentMethod));
            }

            // Execute the query and compute the results
            var bookingServices = await bookingServicesQuery.ToListAsync();

            // Calculate the total revenue and breakdowns
            var reportResult = new RevenueReportDto()
            {
                TotalRevenue = bookingServices.Sum(d => d.Price),
                RevenueByBranch = bookingServices.GroupBy(d => d.Booking.Branch.Name)
                                                 .ToDictionary(g => g.Key, g => g.Sum(d => d.Price)),
                RevenueByService = bookingServices.GroupBy(d => d.Service.Name)
                                                  .ToDictionary(g => g.Key, g => g.Sum(d => d.Price)),
                RevenueByPaymentMethod = bookingServices.SelectMany(d => d.Booking.Transactions).Distinct()
                                            .GroupBy(t => t.PaymentMethod)
                                            .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount))
            };

            // check session for user and if correct and is temp
            return new Response() { Data = reportResult,ResponseCode = Enum.ResponseTypeEnum.Success };
        }


        public async Task<Response> GetAppointmentReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod)
        {
            // Fetch the Booking data with required includes
            var bookingQuery = _unitOfWork.Booking.GetAll()
                .Include(d => d.BookingServices)
                    .ThenInclude(d => d.Service)
                .Include(d => d.Transactions)
                .Include(d => d.Branch)
                .Where(d => d.BookingDate >= startDate && d.BookingDate <= endDate);

            // Apply filtering conditions
            if (branchId != null)
            {
                bookingQuery = bookingQuery.Where(d => d.BranchId == branchId);
            }

            if (serviceId != null)
            {
                bookingQuery = bookingQuery.Where(d => d.BookingServices.Any(bs => bs.ServiceId == serviceId));
            }

            if (paymentMethod != null)
            {
                bookingQuery = bookingQuery.Where(d => d.Transactions.Any(t => t.PaymentMethod == paymentMethod));
            }

            // Execute the query and fetch the results
            var bookings = await bookingQuery.ToListAsync();

            // Calculate the total appointments and breakdowns
            var reportResult = new AppointmentReportDto()
            {
                TotalNumberOfAppointments = bookings.Count(),
                AppointmentByBranch = bookings.GroupBy(d => d.Branch.Name)
                                              .ToDictionary(g => g.Key, g => g.Count()),
                AppointmentByService = bookings.SelectMany(d => d.BookingServices)
                                               .GroupBy(bs => bs.Service.Name)
                                               .ToDictionary(g => g.Key, g => g.Count()),
                AppointmentByStatus = bookings.GroupBy(d => d.Status)
                                              .ToDictionary(g => g.Key, g => g.Count())
            };
            return new Response() { Data = reportResult, ResponseCode = Enum.ResponseTypeEnum.Success };
        }


        public async Task<Response> GetCustomerDemographicsReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod) 
        {
            // Fetch the Client data with related entities
            var clientQuery = _unitOfWork.Client.GetAll()
                .Include(c => c.Bookings).ThenInclude(b => b.BookingServices).ThenInclude(bs => bs.Service)
                .Include(c => c.Bookings).ThenInclude(b => b.Transactions)
                .Include(c => c.Bookings).ThenInclude(b => b.Branch)
                .Where(c => c.Bookings.Any(b => b.BookingDate >= startDate && b.BookingDate <= endDate));

            // Apply additional filtering conditions
            if (branchId != null)
            {
                clientQuery = clientQuery.Where(c => c.Bookings.Any(b => b.BranchId == branchId));
            }

            if (serviceId != null)
            {
                clientQuery = clientQuery.Where(c => c.Bookings.Any(b => b.BookingServices.Any(bs => bs.ServiceId == serviceId)));
            }

            if (paymentMethod != null)
            {
                clientQuery = clientQuery.Where(c => c.Bookings.Any(b => b.Transactions.Any(t => t.PaymentMethod == paymentMethod)));
            }

            // Execute the query and fetch the results
            var clients = await clientQuery.ToListAsync();

            // Calculate demographics data
            var reportResult = new CustomerDemographicsReportDto()
            {
                TotalNumberOfCustomers = clients.Count(),
                CustomerByAgeGroup = clients.GroupBy(c => CalculateAgeGroup(c.Birthdate))
                                            .ToDictionary(g => g.Key, g => g.Count()),
                CustomerByGender = clients.GroupBy(c => c.Gender)
                                          .ToDictionary(g => g.Key, g => g.Count()),
                CustomerByBranch = clients.SelectMany(c => c.Bookings)
                                          .GroupBy(b => b.Branch.Name)
                                          .ToDictionary(g => g.Key, g => g.Select(b => b.ClientId).Distinct().Count())
            };

            // Return the result wrapped in a response object
            return new Response() { Data = reportResult, ResponseCode = Enum.ResponseTypeEnum.Success };


        }
        private string CalculateAgeGroup(DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate.Date > DateTime.Today.AddYears(-age)) age--;

            if (age < 18) return "Under 18";
            if (age >= 18 && age <= 25) return "18-25";
            if (age >= 26 && age <= 35) return "26-35";
            if (age >= 36 && age <= 45) return "36-45";
            if (age >= 46 && age <= 60) return "46-60";
            return "Over 60";
        }


    }
}
