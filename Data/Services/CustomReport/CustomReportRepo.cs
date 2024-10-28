using ART_PACKAGE.Areas.Identity.Data;
using Data.Constants.db;
using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Data.Services.CustomReport;

public class CustomReportRepo : BaseRepo<CustomReportsContext, Dictionary<string, object>>, ICustomReportRepo
{

    private static readonly Dictionary<string, (string op, bool isShared)> OPS = new()
    {
        { "eq"              , ("{0} = {1}"           ,true) },
        { "neq"             , ("{0} <> {1}"          ,true) },
        { "isnull"          , ("{0} IS NULL"         ,true) },
        { "isnotnull"       , ("{0} IS NOT NULL"     ,true) },
        { "isempty"         , ($@"{{0}} = ''"        ,false) },
        { "isnotempty"      , ($@"{{0}} <> ''"       ,false) },
        { "startswith"      , ("{0} LIKE '{1}%'"     ,false) },
        { "doesnotstartwith", ("{0} NOT LIKE '{1}%'" ,false) },
        { "contains"        , ("{0} LIKE '%{1}%'"    ,false) },
        { "doesnotcontain"  , ("{0} NOT LIKE '%{1}%'",false) },
        { "endswith"        , ("{0} LIKE '%{1}'"     ,false) },
        { "doesnotendwith"  , ("{0} NOT LIKE '%{1}'" ,false) },
        { "gte"  ,("{0} >= {1}" ,true)},
        { "gt"   ,("{0} > {1}"  ,true)},
        { "lte"  ,("{0} <= {1}" ,true)},
        { "lt"  , ("{0} < {1}"  ,true)},
    };
    public CustomReportRepo(CustomReportsContext context) : base(context)
    {
    }


    public IEnumerable<GridColumn> GetReportColumns(int reportId)
    {
        ArtCustomReport? Report = _context.ArtCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == reportId);
        return Report.Columns.Select(x => new GridColumn
        {
            name = x.Column,
            isNullable = x.IsNullable,
            type = x.JsType
        });
    }

    public GridResult<Dictionary<string, object>> GetGridData(DbContext schemaContext, ArtCustomReport report, GridRequest request)
    {
        var dbType = schemaContext.Database.IsOracle() ? DbTypes.Oracle : schemaContext.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;

        using (var connection = schemaContext.Database.GetDbConnection())
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var result = new List<Dictionary<string, object>>();
                using var command = connection.CreateCommand();
                command.CommandText = GenerateSql(report, request, dbType);
                IQueryable< Dictionary<string, object>> resultData ;
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var obj = new Dictionary<string, object>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            obj.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                        }
                       result.Add(obj);
                    }
                    resultData = result.AsQueryable();
                }
                var count = GetDataCount(schemaContext, report, request);
                return new GridResult<Dictionary<string, object>>
                {
                    data = resultData,
                    total = count
                };
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }

    public int GetDataCount(DbContext schemaContext, ArtCustomReport report, GridRequest request)
    {
        var dbType = schemaContext.Database.IsOracle() ? DbTypes.Oracle : schemaContext.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;
        using (var connection = schemaContext.Database.GetDbConnection())
        {

       
            
        try
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            using var countCommand = connection.CreateCommand();
            countCommand.CommandText = GenerateSql(report, request, dbType, true);
            using (var reader = countCommand.ExecuteReader())
            {
                    var count = 0;
                   

                    if (reader.Read())
                    {
                         count = reader.GetInt32(0);
                        // Now you have the count value, do whatever you need with it...
                    }

                    return count;
            }
            
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        } 
        
        }

    }
    private string GenerateSql(ArtCustomReport report, GridRequest request, string dbType, bool isCount = false)
    {

        string dbLitral = dbType == DbTypes.Oracle ? @"""{0}""" : dbType == DbTypes.MySql ? @"`{0}`" : "[{0}]";


        var selectLine = isCount ? $"SELECT COUNT(*) " : $"SELECT {string.Join(",", report.Columns.Select(x => string.Format(dbLitral, x.Column)))}";
        var fromLine = $@"FROM {string.Join(".", report.Table.Split(".").Select(x => string.Format(dbLitral, x)))}";
        var whereLine = GenerateWhere(request.Filter, dbType, report.Columns);
        whereLine = string.IsNullOrEmpty(whereLine) ? whereLine : $"WHERE {whereLine}";
        var order = GenerateOderby(request.Sort);
        var oderByLine = string.IsNullOrEmpty(order) ? "ORDER BY 1 ASC" : "ORDER BY " + order;
 
        var skipLine = isCount ? $"" : dbType == DbTypes.MySql? $"LIMIT {request.Take}" : $"OFFSET {request.Skip} ROWS ";
        var takeLine = isCount ? $"" : dbType == DbTypes.MySql ? $"OFFSET {request.Skip}" : $"FETCH NEXT {request.Take} ROWS ONLY";
        return $@"{selectLine}
                  {fromLine}
                  {whereLine}
                  {oderByLine}
                  {skipLine}
                  {takeLine}";
    }

    private string GenerateWhere(Filter filter, string dbType, IEnumerable<ArtReportsColumns> columns)
    {
        string dbLitral = dbType == DbTypes.Oracle ? @"""{0}""" : dbType == DbTypes.MySql ? @"`{0}`" : "[{0}]";



        if (filter is null)
            return string.Empty;


        if (filter.logic is not null)
        {
            List<string> fs = new();
            foreach (var f in filter.filters)
            {
                fs.Add(GenerateWhere(f, dbType, columns));
            }

            return "(" + string.Join($" {filter.logic} ", fs) + ")";
        }
        else
        {
            var column = columns.FirstOrDefault(x => x.Column == filter.field);
            var op = OPS[filter.@operator];
            if (!op.isShared)
            {
                var value = ((JsonElement)filter.value).ToObject<string>();
                return string.Format(op.op, string.Format(dbLitral, filter.field), value);
            }

            if (column.JsType.ToLower() == "string")
            {
                var value = ((JsonElement)filter.value).ToObject<string>();
                return string.Format(op.op, string.Format(dbLitral, filter.field), "'" + value + "'");
            }

            if (column.JsType.ToLower() == "number")
            {
                var value = ((JsonElement)filter.value).ToObject<decimal>();
                return string.Format(op.op, string.Format(dbLitral, filter.field), value);
            }

            if (column.JsType.ToLower() == "date")
            {
                string dbDateTruncation = dbType == DbTypes.Oracle ? "TRUNC({0}) " : dbType == DbTypes.MySql ? @"STR_TO_DATE(`{0}`, '%d-%m-%Y')" : "Convert(date,{0},105)";

                var value = "'" + ((JsonElement)filter.value).ToObject<DateTime>().ToLocalTime().Date.ToString("dd-MM-yyyy") + "'";
                value = dbType == DbTypes.Oracle ? string.Format(dbDateTruncation, string.Format("to_date({0},'dd-MM-yyyy')", value)) : dbType == DbTypes.MySql ? string.Format(dbDateTruncation, string.Format(@"STR_TO_DATE(`{0}`, '%d-%m-%Y')", value)) : string.Format(dbDateTruncation, value);
                var field = string.Format(dbDateTruncation, string.Format(dbLitral, filter.field));
                return string.Format(op.op, field, value);
            }

            return string.Empty;
        }

    }

    private string GenerateOderby(List<SortOption> sortOptions)
    {
        string orderBy = sortOptions is null ? "" : string.Join(" , ", sortOptions.Select(x => $"{x.field} {x.dir}"));
        return orderBy;
    }
    public DbSchema GetReportSchema(int reportId)
    {
        ArtCustomReport? Report = _context.ArtCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == reportId);
        return Report.Schema;
    }

    public IEnumerable<DbObject> GetDbObjectsOf(DbContext schemaContext)
    {
        List<string> databaseSchemas = new ();
        var dbType = schemaContext.Database.IsOracle() ? DbTypes.Oracle : schemaContext.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;
        if (dbType == DbTypes.MySql) { 
            var entityTypes = schemaContext.Model.GetEntityTypes();
            databaseSchemas.Add(schemaContext.Model.GetDefaultSchema());
            foreach (var entityType in entityTypes)
            {
                // Get the schema name for each entity type
                var schemaName = entityType.GetSchema();
                databaseSchemas.Add(schemaName);
                // Do something with the schema name
            } 
        }
  
        var connection = schemaContext.Database.GetDbConnection();
        try
        {
            List<DbObject> dbObjects = new();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = dbType==DbTypes.MySql? GetDbObjectSql(dbType, dbContextSchemas:databaseSchemas.Distinct().Select(s => "'" + s + "'").ToArray()) :  GetDbObjectSql(dbType);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var obj = new DbObject();
                obj.VIEW_NAME = reader.GetString(0);
                obj.TYPE = reader.GetString(1);
                dbObjects.Add(obj);
            }

            return dbObjects;
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }

    public IEnumerable<ColumnDto> GetObjectColumns(DbContext schemaContext, string view, string type)
    {
        var dbType = schemaContext.Database.IsOracle() ? DbTypes.Oracle : schemaContext.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;

        var getColumnsSql = GetObjectColumnsSql(dbType);
        var schemaObjectArr = view.Split(".");
        string schemaSqlName = string.Empty;
        string objectSqlName = string.Empty;


        schemaSqlName = schemaObjectArr[0];
        objectSqlName = schemaObjectArr.Length == 2 ? schemaObjectArr[1] : schemaObjectArr[0];
        var sql = string.Format(getColumnsSql, objectSqlName, type, schemaSqlName);
        var connection = schemaContext.Database.GetDbConnection();
        try
        {
            List<ColumnDto> dbObjectColumns = new();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var column = new ColumnDto();
                column.Name = reader.GetString(0);
                column.SqlDataType = reader.GetString(1);
                column.IsNullable = reader.GetString(2);
                dbObjectColumns.Add(column);
            }
            return dbObjectColumns;
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }

    public bool IsReportExist(int reportId)
    {
        return _context.ArtCustomReports.Any(x => x.Id == reportId);
    }

    public IEnumerable<ChartDataDto> GetReportChartsData(DbContext schemaContext, ArtCustomReport report, GridRequest request)
    {

        var dbType = schemaContext.Database.IsOracle() ? DbTypes.Oracle : schemaContext.Database.IsSqlServer() ? DbTypes.SqlServer : DbTypes.MySql;

        string dbLitral = dbType == DbTypes.Oracle ? @"""{0}""" : dbType == DbTypes.MySql ? @"`{0}`" : "[{0}]";
        var whereLine = GenerateWhere(request.Filter, dbType, report.Columns);
        whereLine = string.IsNullOrEmpty(whereLine) ? whereLine : $"WHERE {whereLine}";
        var fromLine = $@"FROM {string.Join(".", report.Table.Split(".").Select(x => string.Format(dbLitral, x)))}";
        var sql = $@"SELECT COUNT(*) AS {string.Format(dbLitral, "ValField")} , {{0}} AS {string.Format(dbLitral, "CatField")}
                     {fromLine}
                     {whereLine}
                     GROUP BY {{0}}";
        List<ChartDataDto> chartsData = new();
        var connection = schemaContext.Database.GetDbConnection();
        try
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            int i = 0;
            foreach (var chart in report.Charts)
            {
                var chartDataSql = string.Format(sql, string.Format(dbLitral, chart.Column));
                var chartData = new ChartDataDto
                {
                    ChartId = $"chart-{report.Id}-{i}"
                };
                using var command = connection.CreateCommand();
                command.CommandText = chartDataSql;
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new Dictionary<string, object>();

                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        obj.Add(reader.GetName(j), reader.IsDBNull(j) ? null : reader.GetValue(j));
                    }

                    chartData.ChartData.Add(obj);
                }

                chartsData.Add(chartData);
                reader.Close();
                i++;
            }

            return chartsData;
        }
        catch (Exception e)
        {

            throw;
        }
        finally
        {
            connection.Close();
        }

    }



    private string GetObjectColumnsSql(string dbType)
    {
        return dbType switch
        {
            DbTypes.SqlServer => @"SELECT COLUMN_NAME as [Name] ,
                                   DATA_TYPE [SqlDataType], 
                                   IS_NULLABLE [IsNullable]
                            FROM INFORMATION_SCHEMA.COLUMNS c
                            INNER JOIN (Select distinct type ,  name  from  sys.objects) o
                                ON c.TABLE_NAME = o.name
                            WHERE c.TABLE_SCHEMA = N'{2}'
                                AND c.TABLE_NAME = N'{0}'
                                AND o.type = '{1}';",
            DbTypes.Oracle => @"select
                               col.COLUMN_NAME as ""Name"", 
                               col.DATA_TYPE as ""SqlDataType"",
                               col.NULLABLE as ""IsNullable""
                        from sys.all_tab_columns col
                        inner join (    SELECT view_name  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                                        union  all
                                        SELECT table_name as VIEW_NAME , 'U' as TYPE  FROM user_tables  ) v
                        on col.table_name = v.VIEW_NAME and v.view_name = '{0}' and v.TYPE = '{1}'",
            DbTypes.MySql => @"SELECT 
                            COLUMN_NAME AS `Name`, 
                            DATA_TYPE AS `SqlDataType`, 
                            IS_NULLABLE AS `IsNullable`
                        FROM 
                            INFORMATION_SCHEMA.COLUMNS
                        WHERE 
                            TABLE_SCHEMA = '{2}'  -- The schema name
                            AND TABLE_NAME = '{0}'  -- The table name
                            AND EXISTS (
                                SELECT 1
                                FROM INFORMATION_SCHEMA.TABLES
                                WHERE 
                                    TABLE_SCHEMA = '{2}'
                                    AND TABLE_NAME = '{0}'
                                    AND TABLE_TYPE = '{1}'  -- Table type (e.g., 'BASE TABLE' for regular tables)
                            );",
            _ => throw new Exception()
        };
    }

    private string GetDbObjectSql(string dbType, string[]? dbContextSchemas=null)
    {
        string MySqlDbSchemas = "";
        if (dbType==DbTypes.MySql)
        {
            if (dbContextSchemas!=null && dbContextSchemas.Count()>0)
            {
                MySqlDbSchemas = $"AND Table_Schema IN( { string.Join(",", dbContextSchemas)} )";
            }
        }
        return dbType switch
        {
            DbTypes.Oracle => @"SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),view_name)  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                        union  all
                        SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),table_name) as VIEW_NAME , 'U' as TYPE  FROM user_tables  ",
            DbTypes.SqlServer => $@"SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME , type As [TYPE]
                                FROM 
	                                sys.views as v
				 		        union 
                              SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME  , type As [TYPE]
                                FROM 
	                                sys.tables as v;",
            DbTypes.MySql => $@"SELECT 
                            CONCAT(TABLE_SCHEMA, '.', TABLE_NAME) AS VIEW_NAME,
                            TABLE_TYPE AS `TYPE`
                        FROM 
                            INFORMATION_SCHEMA.TABLES 
                        WHERE 
                            TABLE_TYPE = 'VIEW' {MySqlDbSchemas}

                        UNION 

                        SELECT 
                            CONCAT(TABLE_SCHEMA, '.', TABLE_NAME) AS VIEW_NAME,
                            TABLE_TYPE AS `TYPE`
                        FROM 
                            INFORMATION_SCHEMA.TABLES
                        WHERE 
                            TABLE_TYPE = 'BASE TABLE' {MySqlDbSchemas};",
            _ => throw new Exception()
        };
    }

    public ArtCustomReport GetReport(int id)
    {
        var report = _context.ArtCustomReports.Find(id); // Find does not include related data
        if (report is null)
            return null;
        _context.Entry(report).Collection(u => u.Columns).Load();
        _context.Entry(report).Collection(u => u.Charts).Load();
/*        _context.Entry(report).Collection(u => u.Users).Load();
*/        return report;
    }
}