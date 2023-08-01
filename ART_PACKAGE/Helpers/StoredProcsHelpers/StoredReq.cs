using ART_PACKAGE.Helpers.CustomReportHelpers;


namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public class StoredReq
    {
        public KendoRequest req { get; set; } = null!;
        public List<Filters>? procFilters { get; set; }
    }

}
