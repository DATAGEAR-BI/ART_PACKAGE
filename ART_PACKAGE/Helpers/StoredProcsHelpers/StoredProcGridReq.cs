using ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public class StoredProcGridReq
    {
        public List<BuilderFilter>? Filters { get; set; }
        public KendoRequest? Req { get; set; }
    }
}
