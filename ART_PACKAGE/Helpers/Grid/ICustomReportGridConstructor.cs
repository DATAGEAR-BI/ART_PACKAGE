using Data.Services.CustomReport;

namespace ART_PACKAGE.Helpers.Grid
{
    public interface ICustomReportGridConstructor : IGridConstructor<ICustomReportRepo, AuthContext, Dictionary<string, object>>
    {
        public GridIntializationConfiguration IntializeGrid(int reportId);
        public GridResult<Dictionary<string, object>> GetGridData(int reportId, GridRequest request);
        public IEnumerable<ChartDataDto> GetReportChartsData(int reportId, GridRequest request);

        public IEnumerable<DbObject> GetDbObjectsOf(int schema);
        public IEnumerable<ColumnDto> GetObjectColumns(int schema, string view, string type);
        public string ExportGridToCsv(int reportId, ExportRequest exportRequest, string user, string gridId);
    }
}