using System.Linq.Expressions;
using System.Text;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.CustomReport;

public class CustomReportRepo : BaseRepo<AuthContext,object> , ICustomReportRepo
{
    
    private static readonly Dictionary<string, (string op ,bool isShared)> OPS = new()
    {
        { "eq"              , ("{0} = {1}"           ,true) },
        { "neq"             , ("{0} <> {1}"          ,true) },
        { "isnull"          , ("{0} IS NULL"         ,true) },
        { "isnotnull"       , ("{0} IS NOT NULL"     ,true) },
        { "isempty"         , ($@"{{0}} = ''"        ,true) },
        { "isnotempty"      , ($@"{{0}} <> ''"       ,true) },
        { "startswith"      , ("{0} LIKE '{1}%'"     ,true) },
        { "doesnotstartwith", ("{0} NOT LIKE '{1}%'" ,true) },
        { "contains"        , ("{0} LIKE '%{1}%'"    ,true) },
        { "doesnotcontain"  , ("{0} NOT LIKE '%{1}%'",true) },
        { "endswith"        , ("{0} LIKE '%{1}'"     ,true) },
        { "doesnotendwith"  , ("{0} NOT LIKE '%{1}'" ,true) },
        { "gte"  ,("{0} >= {1}" ,true)},
        { "gt"   ,("{0} > {1}"  ,true)},
        { "lte"  ,("{0} <= {1}" ,true)},
        { "lt"  , ("{0} < {1}"  ,true)},
    };
    public CustomReportRepo(AuthContext context) : base(context)
    {
    }


    public IEnumerable<GridColumn> GetReportColumns(int reportId)
    {
        ArtSavedCustomReport? Report = _context.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == reportId);
        return Report.Columns.Select(x => new GridColumn
        {
            name = x.Column, 
            isNullable = x.IsNullable,
            type = x.JsType
        });
    }

    public GridResult<object> GetGridData(DbContext schemaContext,ArtSavedCustomReport report,GridRequest request)
    {
            
        //     dbInstance = dBFactory.GetDbInstance(schema);
        //     string dbtype = db.Database.IsOracle() ? "oracle" : db.Database.IsSqlServer() ? "sqlServer" : "";
        //     string orderBy = obj.Sort is null ? null : string.Join(" , ", obj.Sort.Select(x => $"{x.field} {x.dir}"));
        //     List<ChartData<dynamic>> chartsdata = null;
        //     string filter = obj.Filter.GetFiltersString(dbtype, columns);
        //     if (charts is not null && charts.Count != 0)
        //     {
        //         chartsdata = dbInstance.GetChartData(charts, filter);
        //     }
        //     DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, obj.Take, obj.Skip, orderBy);
        //     return Content(JsonConvert.SerializeObject(new
        //     {
        //         data = data.Data,
        //         total = data.DataCount,
        //         chartdata = chartsdata,
        //         title = Report.Name,
        //         desc = Report.Description,
        //     }
        //     ), "application/json"
        //     );
    }


    private string GenerateSql(ArtSavedCustomReport report, GridRequest request,string dbType)
    {
        string dbLitral = dbType.ToLower() == "oracle" ? @"""{0}""":"[{0}]";
        var selectLine = $"SELECT {string.Join(",", report.Columns.Select(x => string.Format(dbLitral, x.Column)))}";
        var fromLine = $@"FROM {string.Join(",", report.Table.Split(".").Select(x=>string.Format(dbLitral,x)))}";
        
        return string.Empty;
    }


    private string GenerateWhere(Filter filter, string dbType,IEnumerable<ArtSavedReportsColumns> columns)
    {
        StringBuilder where = new StringBuilder();
        string dbLitral = dbType.ToLower() == "oracle" ? @"""{0}""":"[{0}]";
        
        if (filter is null || filter.logic is null)
            return string.Empty;
        
        
        if (filter.logic is not null)
        {
            List<string> fs = new();
            foreach (var f in filter.filters)
            {
                fs.Add(GenerateWhere(f,dbType,columns));
            }

            return "(" + string.Join($" {filter.logic} ", fs)+ ")";
        }
        else
        {
            var column = columns.FirstOrDefault(x => x.Column == filter.field);
            
        }
            
    }
    
    
    public DbSchema GetReportSchema(int reportId)
    {
        ArtSavedCustomReport? Report = _context.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == reportId);
        return Report.Schema;
    }
}