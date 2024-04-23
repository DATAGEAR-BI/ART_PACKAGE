namespace Data.Services.AmlAnalysis
{
    public class QueryBuilderFilter
    {
        public string? id { get; set; }
        public string? field { get; set; }
        public string? label { get; set; }
        public string? type { get; set; }
        public string? input { get; set; }
        public string? values { get; set; }
        public string? value_separator { get; set; }
        public dynamic[]? operators { get; set; }
    }
}
