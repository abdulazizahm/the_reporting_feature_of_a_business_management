using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DTO
{
    public class PaginatorVm
    {
        [Range(0, int.MaxValue)]
        public virtual int SkipCount { get; set; }
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; } = 1000;
    }
}
