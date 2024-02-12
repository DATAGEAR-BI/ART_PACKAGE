using ART_PACKAGE.Areas.Identity.Data;

namespace Data.Services.CustomReport;

public class ReportChartDto
{
    public string ChartId { get; set; }
    public string CategoryField { get; set; } = "CatField";
    public string ValueField { get; set; }= "ValField";
    public string Title { get; set; }
    public ChartType Type { get; set; }
    
}