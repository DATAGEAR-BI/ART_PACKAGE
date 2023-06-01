using ART_PACKAGE.Areas.Identity.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Oracle.ManagedDataAccess.Client;

using System.Data;

using System.Text;
using static Dapper.SqlMapper;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public static class DbContextExtentions
    {
        private static Dictionary<string, string> viewsSql = new Dictionary<string, string>
        {
            {"sqlserver",@"SELECT
	                            SCHEMA_NAME(v.schema_id)+ '.'+ v.name as VIEW_NAME
                           FROM 
	                            sys.views as v;"},
            {"oracle",@"SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),view_name) as VIEW_NAME FROM user_views 
                        union  all
                        SELECT CONCAT(CONCAT((sELECT USER FROM DUAL),'.'),table_name) as VIEW_NAME FROM user_tables "}
        };

        private static Dictionary<string, string> viewsColumnsSql = new Dictionary<string, string>
        {
            {"sqlserver",@"select
                                tab.name as VIEW_NAME, 
                                col.name as COLUMN_NAME
                            from sys.views as tab
                                inner join sys.columns as col
                                    on tab.object_id = col.object_id and tab.name  = '{0}';"},
            {"oracle",@"select
                               col.table_name as VIEW_NAME, 
                               col.column_name as COLUMN_NAME
                        from sys.all_tab_columns col
                        inner join (    SELECT view_name as VIEW_NAME FROM user_views 
                                        union  all
                                        SELECT table_name as VIEW_NAME FROM user_tables ) v
                        on col.table_name = v.VIEW_NAME and v.view_name = '{0}'"}
        };
        private static Dictionary<string, string> DataSql = new Dictionary<string, string>
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
        private static Dictionary<string, string> DataCountSql = new Dictionary<string, string>
        {
            {"sqlserver",@"select Count(*)
                            from {0}
                            {1}"},
            {"oracle",@"select Count(*)
                            from {0}
                            {1}"}
        };
        public static List<string> GetViewsNames(this DbContext db)

        {
            var isSqlServer = db.Database.IsSqlServer();
            var isOracle = db.Database.IsOracle();
            string sql = "";
            if (isSqlServer) sql = viewsSql["sqlserver"];
            else if (isOracle) sql = viewsSql["oracle"];

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());


            var views = conn.Query<View>(sql).Select(x => x.VIEW_NAME).ToList();
            return views;




        }
        public static List<string> GetViewColumns(this DbContext db, string view)

        {

            var isSqlServer = db.Database.IsSqlServer();
            var isOracle = db.Database.IsOracle();
            string sql = "";
            if (isSqlServer) sql = string.Format(viewsColumnsSql["sqlserver"], view);
            else if (isOracle) sql = string.Format(viewsColumnsSql["oracle"], view);

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());


            var columns = conn.Query<ViewColumn>(sql).Select(x => x.COLUMN_NAME).ToList();
            return columns;
        }
        public static DataResult GetData(this DbContext db, string view, string[]? columns = null, string filters = null, long take = 0, int skip = 0, string orderBy = null)

        {
            var isSqlServer = db.Database.IsSqlServer();
            var isOracle = db.Database.IsOracle();
            string sql = "";
            string sqlCount = "";
            string oracleNormalizedName = "";
            var progection = string.Join(", ", isOracle ? columns.Select(x => @$"""{x}""") : columns);
            var restriction = !string.IsNullOrEmpty(filters) ? "WHERE " + filters : null;

            if (isOracle)
            {
                oracleNormalizedName = string.Join(".", view.Split(".").Select(x => @$"""{x}"""));
            }
            if (isSqlServer)
            {

                sqlCount = string.Format(DataCountSql["sqlserver"], view, restriction);
            }
            else if (isOracle)
            {
                sqlCount = string.Format(DataCountSql["oracle"], oracleNormalizedName, restriction);
            };

            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());

            var count = conn.Query<long>(sqlCount).Single();

            if (take == 0)
                take = count;

            if (isSqlServer)
                orderBy = string.IsNullOrEmpty(orderBy) ? "ORDER BY(SELECT NULL)" : "ORDER BY " + orderBy;

            if (isOracle)
                orderBy = string.IsNullOrEmpty(orderBy) ? "" : "ORDER BY " + orderBy;

            if (isSqlServer) sql = string.Format(DataSql["sqlserver"], progection, view, restriction, orderBy, skip, take);
            else if (isOracle) sql = string.Format(DataSql["oracle"], progection, oracleNormalizedName, restriction, orderBy, skip, take);



            var data = conn.Query(sql, commandTimeout: 120).ToList();
            return new DataResult { Data = data, DataCount = count };
        }


        public static List<ChartData<dynamic>> GetChartData(this DbContext db, List<ArtSavedReportsChart> charts, string filters = null)
        {
            var orclSql = @"OPEN {3} FOR SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            var Sql = @"SELECT {0} As CAT , Count({0}) As AGG FROM {1} {2} GROUP BY {0};";
            var isSqlServer = db.Database.IsSqlServer();
            var isOracle = db.Database.IsOracle();
            var restriction = !string.IsNullOrEmpty(filters) ? "WHERE " + filters : null;
            StringBuilder _sb = new StringBuilder();
            GridReader result = null;
            IDbConnection conn = isSqlServer ? new SqlConnection(db.Database.GetConnectionString())
                                             : new OracleConnection(db.Database.GetConnectionString());
            List<ChartData<dynamic>> data = new();
            string query = string.Empty;
            if (isOracle)
            {
                _sb.AppendLine("BEGIN");
                OracleDynamicParameters dynParams = new OracleDynamicParameters();
                charts.Select((x, i) => (x, i)).ToList().ForEach(rec =>
                {

                    _sb.AppendLine(string.Format(orclSql, rec.x.Column, rec.x.Report.Table, restriction, $":rslt{rec.i}"));
                    dynParams.Add($":rslt{rec.i}", OracleDbType.RefCursor, ParameterDirection.Output);


                });
                _sb.AppendLine("END;");
                query = _sb.ToString();
                result = conn.QueryMultiple(query, param: dynParams);
            }
            else if (isSqlServer)
            {

                charts.Select((x, i) => (x, i)).ToList().ForEach(rec =>
                {

                    _sb.AppendLine(string.Format(Sql, rec.x.Column, rec.x.Report.Table, restriction));
                });
                query = _sb.ToString();
                result = conn.QueryMultiple(query);
            }










            foreach (var (chart, i) in charts.Select((chart, i) => (chart, i)))
            {
                ChartData<dynamic> d = new ChartData<dynamic>()
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

        public class View
        {
            public string VIEW_NAME { get; set; }
        }

        public class ViewColumn
        {
            public string VIEW_NAME { get; set; }
            public string COLUMN_NAME { get; set; }
        }

    }
}
