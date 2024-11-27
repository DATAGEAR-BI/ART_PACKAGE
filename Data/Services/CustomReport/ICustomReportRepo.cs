using ART_PACKAGE.Areas.Identity.Data;
using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.CustomReport;

public interface ICustomReportRepo : IBaseRepo<CustomReportsContext,Dictionary<string, object>>
{
    public IEnumerable<GridColumn> GetReportColumns(int reportId);
    public GridResult<Dictionary<string, object>> GetGridData(DbContext schemaContext,ArtCustomReport report,KendoGridRequest request);
    public DbSchema GetReportSchema(int reportId);

    public IEnumerable<DbObject> GetDbObjectsOf(DbContext schemaContext);

    public IEnumerable<ColumnDto> GetObjectColumns(DbContext schemaContext, string view, string type);

    public bool IsReportExist(int reportId);
    public int GetDataCount(DbContext schemaContext, ArtCustomReport report, KendoGridRequest request);

    public IEnumerable<ChartDataDto> GetReportChartsData(DbContext schemaContext,ArtCustomReport report,KendoGridRequest request);
    
    public ArtCustomReport GetReport(int id);
}