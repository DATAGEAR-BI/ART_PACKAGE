namespace Data.Services.CustomReport;

public class ChartDataDto
{
    public string ChartId { get; set; }
    public List<Dictionary<string, object>> ChartData { get; set; } = new List<Dictionary<string, object>>();
}