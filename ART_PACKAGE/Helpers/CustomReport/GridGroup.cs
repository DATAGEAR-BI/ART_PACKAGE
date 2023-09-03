namespace ART_PACKAGE.Helpers.CustomReport
{
    public class GridGroup
    {
        public string field { get; set; } = null!;
        public string dir { get; set; } = null!;

        public List<GridAggregate>? aggregates { get; set; }
    }
}
