using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.Enum
{
    public enum ResponseTypeEnum
    {
        Error = 0,
        Success = 1,
        Warning = 2,
        UnAuthorized = 3,
        SessionExpired = 4,
        Exception = 5,
        Cached = 6,
        InProgress = 7,
        ComplateScoring = 8,
        NotVerified = 9,
    }
}
