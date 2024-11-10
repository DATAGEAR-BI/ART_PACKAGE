using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Services.CustomReport;

public class SaveReportDto
{
    public string Table { get; set; } = null!;
    public List<ColumnDto>? Columns { get; set; }
    public List<ChartDto>? Charts { get; set; }
    public string Title { get; set; } = null!;
    public string ObjectType { get; set; } = null!;
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public DbSchema Schema { get; set; }
}