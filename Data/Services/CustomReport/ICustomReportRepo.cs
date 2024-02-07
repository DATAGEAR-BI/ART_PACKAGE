using ART_PACKAGE.Areas.Identity.Data;
using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.CustomReport;

public interface ICustomReportRepo : IBaseRepo<AuthContext,object>
{
    public IEnumerable<GridColumn> GetReportColumns(int reportId);
    public GridResult<object> GetGridData(DbContext schemaContext,ArtSavedCustomReport report,GridRequest request);
    public DbSchema GetReportSchema(int reportId);
}