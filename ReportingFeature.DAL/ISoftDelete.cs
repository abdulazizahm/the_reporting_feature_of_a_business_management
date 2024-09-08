using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
