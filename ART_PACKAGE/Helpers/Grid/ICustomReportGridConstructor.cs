using ART_PACKAGE.Areas.Identity.Data;
using Data.Services.CustomReport;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;

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
        public Task<byte[]> ExportGridToPdf(int reportId, ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, Expression<Func<Dictionary<string, object>, bool>>? baseCondition = null);

    }
}