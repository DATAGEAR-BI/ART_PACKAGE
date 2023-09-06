namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class RouteRequest
    {
        public List<string> Entities { get; set; } = new();
        public string Comment { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string QueueCode { get; set; } = string.Empty;
    }
}
