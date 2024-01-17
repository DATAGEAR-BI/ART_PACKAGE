using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public class CustumReportViewmodel
    {
        public string Table { get; set; } = null!;
        public List<ViewColumn>? Columns { get; set; }
        public List<Chart>? Charts { get; set; }
        public string Title { get; set; } = null!;
        public string ObjectType { get; set; } = null!;
        public string? Description { get; set; }
        public DbSchema Schema { get; set; }
    }
}
