using System.ComponentModel.DataAnnotations;

namespace ReportingFeature.DTO
{
    public class SearchVM : PaginatorVm
    {
        public string? Search { get; set; }
        public string? Sorting { get; set; }
    }
}
