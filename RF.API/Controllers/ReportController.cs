using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportingFeature.Business;
using ReportingFeature.DTO;

namespace RF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(ReportManager _reportManager) : ControllerBase
    {
        [HttpGet("revenue")]
        public async Task<Response> GetRevenueReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod) 
        {
            return await _reportManager.GetRevenueReport(startDate, endDate, branchId, serviceId, paymentMethod);
        }
        [HttpGet("appointments")]
        public async Task<Response> GetAppointmentReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod)
        {
            return await _reportManager.GetAppointmentReport(startDate, endDate, branchId, serviceId, paymentMethod);
        }
        [HttpGet("customer-demographics")]
        public async Task<Response> GetCustomerDemographicsReport(DateTime startDate, DateTime endDate, int? branchId, int? serviceId, string? paymentMethod)
        {
            return await _reportManager.GetCustomerDemographicsReport(startDate, endDate, branchId, serviceId, paymentMethod);
        }

    }
}
