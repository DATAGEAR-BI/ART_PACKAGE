using ART_PACKAGE.Areas.Identity.Data;

namespace Data.Services.CustomReport;

public class ChartDto
{
    public string Title { get; set; }
    public string Column { get; set; }
    public ChartType Type { get; set; }
}