namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public class StoredProcGridReq
    {
        public List<BuilderFilter>? Filters { get; set; }
        public GridRequest? Req { get; set; }
    }
}
