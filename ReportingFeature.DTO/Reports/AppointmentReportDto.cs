using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReportingFeature.DTO.Reports
{
    public class AppointmentReportDto
    {
        public int TotalNumberOfAppointments { get; set; }
        public Dictionary<string, int> AppointmentByBranch { get; set; } // Key: Branch Name, Value: Count
        public Dictionary<string, int> AppointmentByService { get; set; } // Key: Service Name, Value: Count
        public Dictionary<string, int> AppointmentByStatus { get; set; } // Key: Status, Value: Count
    }
}
