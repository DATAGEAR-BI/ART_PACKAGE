using Data.Constants.db;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace ART_PACKAGE.Helpers.StoredProcsHelpers
{
    public static class StoredProcFiltersExtentions
    {
        public static IEnumerable<DbParameter> MapToParameters(this List<Filters>? filters, string dbType)
        {
            return dbType switch
            {
                DbTypes.SqlServer => filters.Select(x =>
                                    {
                                        return x.id.ToLower() == "startdate"
                                            ? new SqlParameter("@V_START_DATE", SqlDbType.Date) { Value = x.value }
                                            : x.id.ToLower() == "enddate"
                                            ? new SqlParameter("@V_END_DATE", SqlDbType.Date) { Value = x.value }
                                            : new SqlParameter(x.id, SqlDbType.Date) { Value = x.value };
                                    }),
                DbTypes.Oracle => filters.Select(x => new OracleParameter(x.id, OracleDbType.Varchar2, ParameterDirection.Input) { Value = x.value }).Append(new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)),
                _ => Enumerable.Empty<DbParameter>(),
            };
        }

        public static IEnumerable<DbParameter> MapToParameters(this List<BuilderFilter>? filters, string dbType)
        {
            List<DbParameter> @params = new();
            filters.ForEach(f =>
            {
                bool converted = DateTime.TryParse(f.Value, out DateTime dt);
                string strVal = string.Empty;
                strVal = converted ? dt.ToString("yyyy-MM-dd") : f.Value;

                if (dbType == DbTypes.SqlServer)
                {
                    if (f.Field.ToLower() == "startdate")
                    {
                        @params.Add(new SqlParameter("@V_START_DATE", SqlDbType.Date) { Value = strVal });
                    }
                    else if (f.Field.ToLower() == "enddate")
                    {
                        @params.Add(new SqlParameter("@V_END_DATE", SqlDbType.Date) { Value = strVal });
                    }
                    else
                    {
                        @params.Add(new SqlParameter(f.Field, SqlDbType.Date) { Value = strVal });
                    }
                }
                else if (dbType == DbTypes.Oracle)
                {
                    @params.Add(new OracleParameter(f.Field, OracleDbType.Varchar2, ParameterDirection.Input) { Value = strVal });
                }
            });

            if (dbType == DbTypes.Oracle)
            {
                @params.Add(new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output));
            }

            return @params;
        }
    }
}
