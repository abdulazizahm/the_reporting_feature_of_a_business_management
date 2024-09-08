using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DTO.Reports
{
    public class CustomerDemographicsReportDto
    {
        public int TotalNumberOfCustomers { get; set; }
        public Dictionary<string, int> CustomerByAgeGroup { get; set; } // Key: Age Group, Value: Count
        public Dictionary<string, int> CustomerByGender { get; set; } // Key: Gender, Value: Count
        public Dictionary<string, int> CustomerByBranch { get; set; } // Key: Branch Name, Value: Count of Unique Customers
    }
}
