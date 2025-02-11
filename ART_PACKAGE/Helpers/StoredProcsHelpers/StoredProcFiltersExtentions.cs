﻿using Data.Constants.db;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
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
                DbTypes.MySql => filters.Select(x => {
                    return x.id.ToLower() == "startdate"
                                            ? new MySqlParameter("V_START_DATE", MySqlDbType.VarChar) { Value = x.value }
                                            : x.id.ToLower() == "enddate"
                                            ? new MySqlParameter("V_END_DATE", MySqlDbType.VarChar) { Value = x.value }
                                            : new MySqlParameter(x.id, MySqlDbType.Date) { Value = x.value };
                }),
                _ => Enumerable.Empty<DbParameter>(),

            };
        }
    }
}
