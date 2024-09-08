using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DTO.Reports
{
    public class RevenueReportDto
    {
        public decimal TotalRevenue { get; set; }
        public Dictionary<string, decimal> RevenueByBranch { get; set; } // Key: BranchId, Value: Revenue
        public Dictionary<string, decimal> RevenueByService { get; set; } // Key: ServiceId, Value: Revenue
        public Dictionary<string, decimal> RevenueByPaymentMethod { get; set; } // Key: PaymentMethod, Value: Revenue
    }
}
