using ART_PACKAGE.Areas.Identity.Data;
using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class CustumReportViewmodel
    {
        public string Table { get; set; } = null!;
        public List<string>? Columns { get; set; }
        public List<Chart>? Charts { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DbSchema Schema { get; set; }
    }
}
