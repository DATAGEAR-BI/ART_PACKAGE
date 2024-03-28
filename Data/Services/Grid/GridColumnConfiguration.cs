namespace Data.Services.Grid
{
    public class GridColumnConfiguration
    {
        public string DisplayName { get; set; }
        public string Format { get; set; }
        public bool isLargeText { get; set; }
        public GridAggregateType AggType { get; set; }
        public string? AggText { get; set; }
        public string Template { get; set; }
        public string Filter { get; set; }
    }
    public enum GridAggregateType
    {
        none,
        sum,
        average,
        count
    }
}
