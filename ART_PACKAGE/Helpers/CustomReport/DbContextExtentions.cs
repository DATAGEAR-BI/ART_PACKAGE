using ART_PACKAGE.Areas.Identity.Data;
using Dapper;
using Data.Constants.db;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

using System.Data;

using System.Text;
using static Dapper.SqlMapper;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public static partial class DbContextExtentions
    {
        private static readonly Dictionary<string, string> viewsSql = new()
        {
            {DbTypes.SqlServer,@"SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME , type As [TYPE]
                            FROM 
	                            sys.views as v
						    union 
                            SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME  , type As [TYPE]
                            FROM 
	                            sys.tables as v;"},
            {DbTypes.Oracle,@"SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),view_name)  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                        union  all
                        SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),table_name) as VIEW_NAME , 'U' as TYPE  FROM user_tables  "},
            {DbTypes.MySql,@"SELECT 
                            CONCAT(TABLE_SCHEMA, '.', TABLE_NAME) AS VIEW_NAME, 
                            'VIEW' AS `TYPE`
                        FROM 
                            INFORMATION_SCHEMA.TABLES
                        WHERE 
                            TABLE_TYPE = 'VIEW'

                        UNION

                        SELECT 
                            CONCAT(TABLE_SCHEMA, '.', TABLE_NAME) AS VIEW_NAME, 
                            'TABLE' AS `TYPE`
                        FROM 
                            INFORMATION_SCHEMA.TABLES
                        WHERE 
                            TABLE_TYPE = 'BASE TABLE'; "}
        };

        private static readonly Dictionary<string, string> viewsColumnsSql = new()
        {
            {DbTypes.SqlServer,@"SELECT COLUMN_NAME as [Name] ,
                                   DATA_TYPE [SqlDataType], 
                                   IS_NULLABLE [IsNullable]
                            FROM INFORMATION_SCHEMA.COLUMNS c
                            INNER JOIN (Select distinct type ,  name  from  sys.objects) o
                                ON c.TABLE_NAME = o.name
                            WHERE c.TABLE_SCHEMA = N'{0}'
                                AND c.TABLE_NAME = N'{1}'
                                AND o.type = '{2}';"},
            {DbTypes.Oracle,@"select
                               col.COLUMN_NAME as ""Name"", 
                               col.DATA_TYPE as ""SqlDataType"",
                               col.NULLABLE as ""IsNullable""
                        from sys.all_tab_columns col
                        inner join (    SELECT view_name  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                                        union  all
                                        SELECT table_name as VIEW_NAME , 'U' as TYPE  FROM user_tables  ) v
                        on col.table_name = v.VIEW_NAME and v.view_name = '{0}' and v.TYPE = '{1}'"},
             {DbTypes.MySql,@"SELECT 
                        COLUMN_NAME AS `Name`,
                        DATA_TYPE AS `SqlDataType`,
                        IS_NULLABLE AS `IsNullable`
                    FROM 
                        INFORMATION_SCHEMA.COLUMNS
                    WHERE 
                        TABLE_SCHEMA = '{0}'  -- Schema name
                        AND TABLE_NAME = '{1}'  -- Table or view name
                        AND EXISTS (
                            SELECT 1
                            FROM INFORMATION_SCHEMA.TABLES
                            WHERE 
                                TABLE_SCHEMA = '{0}'
                                AND TABLE_NAME = '{1}'
                                AND TABLE_TYPE = '{2}'  -- 'BASE TABLE' for tables, 'VIEW' for views
                        ); "}
        };
        private static readonly Dictionary<string, string> DataSql = new()
        {
            {DbTypes.SqlServer,@"select {0}
                            from {1}
                            {2}
                            {3}
                            OFFSET     {4} ROWS       
                            FETCH NEXT {5} ROWS ONLY"},
            {DbTypes.Oracle,@"select {0}
                            from {1}
                            {2}
                            {3}
                        OFFSET     {4} ROWS       
                        FETCH NEXT {5} ROWS ONLY"},
            {DbTypes.MySql,@"SELECT {0}  -- Columns to select
                        FROM {1}  -- Table to select from
                        {2}  -- Additional conditions (e.g., WHERE clauses)
                        {3}  -- Grouping, ordering, or joins
                        LIMIT {4}, {5}  -- Pagination (offset, row count)"}
        };
        private static readonly Dictionary<string, string> DataCountSql = new()
        {
            {DbTypes.SqlServer,@"select Count(*)
                            from {0}
                            {1}"},
            {DbTypes.Oracle,@"select Count(*)
                            from {0}
                            {1}"},
            {DbTypes.MySql,@"select Count(*)
                            from {0}
                            {1}" }
        };
        public static IEnumerable<View> GetViewsNames(this DbContext db)

        {
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            bool isMySql = db.Database.IsMySql();
            string sql = "";
            if (isSqlServer)
            {
                sql = viewsSql[DbTypes.SqlServer];
            }
            else if (isOracle)
            {
                sql = viewsSql[DbTypes.Oracle];
            }
            else if(isMySql)
            {
                sql = viewsSql[DbTypes.MySql];
            }

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : isOracle ? new OracleConnection(db.Database.GetConnectionString()) : new MySqlConnection(db.Database.GetConnectionString());


            IEnumerable<View> views = conn.Query<View>(sql);
            return views;




        }
        public static IEnumerable<ViewColumn> GetViewColumns(this DbContext db, string view, string type)

        {
            string schema = view.Split('.')[0];
            string viewName = view.Split('.')[1];
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            bool isMySql = db.Database.IsMySql();
            string sql = "";
            if (isSqlServer)
            {
                sql = string.Format(viewsColumnsSql[DbTypes.SqlServer], schema, viewName, type);
            }
            else if (isOracle)
            {
                sql = string.Format(viewsColumnsSql[DbTypes.Oracle], viewName, type);
            }
            else if(isMySql)
            {
                sql = string.Format(viewsColumnsSql[DbTypes.MySql], schema, viewName, type);
            }
            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                            : isOracle ? new OracleConnection(db.Database.GetConnectionString()) : new MySqlConnection(db.Database.GetConnectionString());


            IEnumerable<ViewColumn> columns = conn.Query<ViewColumn>(sql);
            return columns;
        }
        public static DataResult GetData(this DbContext db, string view, string[]? columns = null, string filters = null, long take = 0, int skip = 0, string orderBy = null)

        {
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            bool isMySql = db.Database.IsMySql();

            string sql = "";
            string sqlCount = "";
            string NormalizedName = "";
            string progection = string.Join(", ", isOracle ? columns.Select(x => @$"""{x}""") : columns);
            string? restriction = !string.IsNullOrEmpty(filters) ? "WHERE " + filters : null;

            if (isSqlServer)
            {
                NormalizedName = string.Join(".", view.Split(".").Select(x => @$"[{x}]"));
                sqlCount = string.Format(DataCountSql[DbTypes.SqlServer], NormalizedName, restriction);
            }
            else if (isOracle)
            {
                NormalizedName = string.Join(".", view.Split(".").Select(x => @$"""{x}"""));
                sqlCount = string.Format(DataCountSql[DbTypes.Oracle], NormalizedName, restriction);
            }
            else if (isMySql)
            {
                NormalizedName = string.Join(".", view.Split(".").Select(x => @$"""{x}"""));
                sqlCount = string.Format(DataCountSql[DbTypes.MySql], NormalizedName, restriction);
            }

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                            : isOracle ? new OracleConnection(db.Database.GetConnectionString()) : new MySqlConnection(db.Database.GetConnectionString());

            long count = conn.Query<long>(sqlCount).Single();

            if (take == 0)
            {
                take = count;
            }

            if (isSqlServer)
            {
                orderBy = string.IsNullOrEmpty(orderBy) ? "ORDER BY(SELECT NULL)" : "ORDER BY " + orderBy;
            }
            if (isOracle)
            {
                orderBy = string.IsNullOrEmpty(orderBy) ? "" : "ORDER BY " + orderBy;
            }
            if (isMySql)
            {
                orderBy = string.IsNullOrEmpty(orderBy) ? "ORDER BY(SELECT NULL)" : "ORDER BY " + orderBy;
            }

            if (isSqlServer)
            {
                sql = string.Format(DataSql[DbTypes.SqlServer], progection, NormalizedName, restriction, orderBy, skip, take);
            }
            else if (isOracle)
            {
                sql = string.Format(DataSql[DbTypes.Oracle], progection, NormalizedName, restriction, orderBy, skip, take);
            }
            else if(isMySql)
            {
                sql = string.Format(DataSql[DbTypes.MySql], progection, NormalizedName, restriction, orderBy, skip, take);
            }

            List<dynamic> data = conn.Query(sql, commandTimeout: 120).ToList();
            return new DataResult { Data = data, DataCount = count };
        }


        public static List<ChartData<dynamic>> GetChartData(this DbContext db, List<ArtSavedReportsChart> charts, string filters = null)
        {
            string orclSql = @"OPEN {3} FOR SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            string Sql = @"SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            string mySql = @"SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            bool isMySql = db.Database.IsMySql();

            string? restriction = !string.IsNullOrEmpty(filters) ? "WHERE " + filters : null;
            StringBuilder _sb = new();
            GridReader result = null;
            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());
            List<ChartData<dynamic>> data = new();
            string query = string.Empty;
            if (isOracle)
            {
                _ = _sb.AppendLine("BEGIN");
                OracleDynamicParameters dynParams = new();
                charts.Select((x, i) => (x, i)).ToList().ForEach(rec =>
                {

                    _ = _sb.AppendLine(string.Format(orclSql, rec.x.Column, rec.x.Report.Table, restriction, $":rslt{rec.i}"));
                    dynParams.Add($":rslt{rec.i}", OracleDbType.RefCursor, ParameterDirection.Output);


                });
                _ = _sb.AppendLine("END;");
                query = _sb.ToString();
                result = conn.QueryMultiple(query, param: dynParams);
            }
            else if (isSqlServer)
            {

                charts.Select((x, i) => (x, i)).ToList().ForEach(rec =>
                {

                    _ = _sb.AppendLine(string.Format(Sql, rec.x.Column, rec.x.Report.Table, restriction));
                });
                query = _sb.ToString();
                if (!string.IsNullOrEmpty(query))
                {
                    result = conn.QueryMultiple(query);
                }
            }

            else if (isMySql)
            {
                charts.Select((x, i) => (x, i)).ToList().ForEach(rec =>
                {

                    _ = _sb.AppendLine(string.Format(Sql, rec.x.Column, rec.x.Report.Table, restriction));
                });
                query = _sb.ToString();
                if (!string.IsNullOrEmpty(query))
                {
                    result = conn.QueryMultiple(query);
                }
            }








            foreach ((ArtSavedReportsChart chart, int i) in charts.Select((chart, i) => (chart, i)))
            {
                ChartData<dynamic> d = new()
                {
                    ChartId = $"chart-{i}",
                    Data = result.Read().ToList(),
                    Title = chart.Title,
                    Cat = "CAT",
                    Val = "AGG"

                };
                data.Add(d);
            }
            return data;
        }

        public class DataResult
        {
            public long DataCount { get; set; }
            public List<dynamic> Data { get; set; }
        }

    }
}
