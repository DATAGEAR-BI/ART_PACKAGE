using System.Collections.Generic;
using System.Linq;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class KendoDataDesc<T> 
    {
        public IQueryable<T> Data { get; set; }
        public List<ColumnsDto> Columns { get; set; }

        public decimal Total { get; set; }
    }
}
