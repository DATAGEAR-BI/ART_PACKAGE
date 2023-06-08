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
            switch (dbType)
            {
                case DbTypes.SqlServer:
                    return filters.Select(x =>
                    {
                        if (x.id.ToLower() == "startdate") return new SqlParameter("@V_START_DATE", SqlDbType.Date) { Value = x.value };
                        if (x.id.ToLower() == "enddate") return new SqlParameter("@V_END_DATE", SqlDbType.Date) { Value = x.value };
                        return new SqlParameter(x.id, SqlDbType.Date) { Value = x.value };
                    });

                case DbTypes.Oracle:
                    return filters.Select(x => new OracleParameter(x.id, OracleDbType.Varchar2, ParameterDirection.Input) { Value = x.value }).Append(new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output));

                default:
                    return Enumerable.Empty<DbParameter>();
            }
        }
    }
}
