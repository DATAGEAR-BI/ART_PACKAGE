namespace Data.Services.Grid;

public class ExportRequest
{
    public GridRequest DataReq { get; set; }
    public List<string> IncludedColumns { get; set; }
}