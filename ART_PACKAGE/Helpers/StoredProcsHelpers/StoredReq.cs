using ART_PACKAGE.Helpers.CustomReportHelpers;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public class StoredReq
    {
        public KendoRequest req { get; set; } = null!;
        public List<Filters>? procFilters { get; set; }
    }

}
