namespace Data.Services.Grid;

public class ExportRequest
{
    public KendoGridRequest DataReq { get; set; }
    public List<string> IncludedColumns { get; set; }
}