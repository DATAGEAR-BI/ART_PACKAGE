using Data.Constants.db;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Data.Services.QueryBuilder
{
    public static class StoredProcFiltersExtentions
    {

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
