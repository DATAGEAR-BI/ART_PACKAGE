using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            {"sqlserver",@"SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME , type As [TYPE]
                            FROM 
	                            sys.views as v
						    union 
                            SELECT SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME  , type As [TYPE]
                            FROM 
	                            sys.tables as v;"},
            {"oracle",@"SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),view_name)  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                        union  all
                        SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),table_name) as VIEW_NAME , 'U' as TYPE  FROM user_tables  "}
        };

        private static readonly Dictionary<string, string> viewsColumnsSql = new()
        {
            {"sqlserver",@"SELECT COLUMN_NAME as [Name] ,
                                   DATA_TYPE [SqlDataType], 
                                   IS_NULLABLE [IsNullable]
                            FROM INFORMATION_SCHEMA.COLUMNS c
                            INNER JOIN (Select distinct type ,  name  from  sys.objects) o
                                ON c.TABLE_NAME = o.name
                            WHERE c.TABLE_SCHEMA = N'{0}'
                                AND c.TABLE_NAME = N'{1}'
                                AND o.type = '{2}';"},
            {"oracle",@"select
                               col.COLUMN_NAME as ""Name"", 
                               col.DATA_TYPE as ""SqlDataType"",
                               col.NULLABLE as ""IsNullable""
                        from sys.all_tab_columns col
                        inner join (    SELECT view_name  as VIEW_NAME  , 'V' as TYPE  FROM user_views 
                                        union  all
                                        SELECT table_name as VIEW_NAME , 'U' as TYPE  FROM user_tables  ) v
                        on col.table_name = v.VIEW_NAME and v.view_name = '{0}' and v.TYPE = '{1}'"}
        };
        private static readonly Dictionary<string, string> DataSql = new()
        {
            {"sqlserver",@"select {0}
                            from {1}
                            {2}
                            {3}
                            OFFSET     {4} ROWS       
                            FETCH NEXT {5} ROWS ONLY"},
            {"oracle",@"select {0}
                            from {1}
                            {2}
                            {3}
                        OFFSET     {4} ROWS       
                        FETCH NEXT {5} ROWS ONLY"}
        };
        private static readonly Dictionary<string, string> DataCountSql = new()
        {
            {"sqlserver",@"select Count(*)
                            from {0}
                            {1}"},
            {"oracle",@"select Count(*)
                            from {0}
                            {1}"}
        };
        public static IEnumerable<View> GetViewsNames(this DbContext db)

        {
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            string sql = "";
            if (isSqlServer)
            {
                sql = viewsSql["sqlserver"];
            }
            else if (isOracle)
            {
                sql = viewsSql["oracle"];
            }

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());


            IEnumerable<View> views = conn.Query<View>(sql);
            return views;




        }
        public static IEnumerable<ViewColumn> GetViewColumns(this DbContext db, string view, string type)

        {
            string schema = view.Split('.')[0];
            string viewName = view.Split('.')[1];
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            string sql = "";
            if (isSqlServer)
            {
                sql = string.Format(viewsColumnsSql["sqlserver"], schema, viewName, type);
            }
            else if (isOracle)
            {
                sql = string.Format(viewsColumnsSql["oracle"], viewName, type);
            }

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());


            IEnumerable<ViewColumn> columns = conn.Query<ViewColumn>(sql);
            return columns;
        }
        public static DataResult GetData(this DbContext db, string view, string[]? columns = null, string filters = null, long take = 0, int skip = 0, string orderBy = null)
        {
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
            string sql = "";
            string sqlCount = "";
            string NormalizedName = "";
            string progection = string.Join(", ", isOracle ? columns.Select(x => @$"""{x}""") : columns);
            string? restriction = !string.IsNullOrEmpty(filters) ? "WHERE " + filters : null;
            if (isOracle)
            {

            }
            if (isSqlServer)
            {
                NormalizedName = string.Join(".", view.Split(".").Select(x => @$"[{x}]"));
                sqlCount = string.Format(DataCountSql["sqlserver"], NormalizedName, restriction);
            }
            else if (isOracle)
            {
                NormalizedName = string.Join(".", view.Split(".").Select(x => @$"""{x}"""));
                sqlCount = string.Format(DataCountSql["oracle"], NormalizedName, restriction);
            };

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());

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

            if (isSqlServer)
            {
                sql = string.Format(DataSql["sqlserver"], progection, NormalizedName, restriction, orderBy, skip, take);
            }
            else if (isOracle)
            {
                sql = string.Format(DataSql["oracle"], progection, NormalizedName, restriction, orderBy, skip, take);
            }

            List<dynamic> data = conn.Query(sql, commandTimeout: 120).ToList();
            return new DataResult { Data = data, DataCount = count };
        }


        public static List<ChartData<dynamic>> GetChartData(this DbContext db, List<ArtSavedReportsChart> charts, string filters = null)
        {
            string orclSql = @"OPEN {3} FOR SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            string Sql = @"SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            bool isSqlServer = db.Database.IsSqlServer();
            bool isOracle = db.Database.IsOracle();
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










            foreach ((ArtSavedReportsChart chart, int i) in charts.Select((chart, i) => (chart, i)))
            {
                ChartData<dynamic> d = new()
                {
                    ChartId = $"chart-{i}",
                    Data = result.Read().ToList(),
                    Title = chart.Title,
                    Cat = "CAT",
                    Val = "AGG",
                    Type = chart.Type,

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
