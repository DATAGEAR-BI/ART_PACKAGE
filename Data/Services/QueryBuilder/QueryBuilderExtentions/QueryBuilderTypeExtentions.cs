using Data.Constants.db;
using Data.Services.Grid;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace Data.Services.QueryBuilder
{
    public static class QueryBuilderTypeExtentions
    {
        private static readonly HashSet<Type> IntTypes = new()
        {
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort)
        };
        private static readonly HashSet<Type> DoubleTypes = new()
        {
            typeof(decimal),
            typeof(float),
            typeof(double),
        };
        private static readonly HashSet<Type> DateTypes = new()
        {
            typeof(DateTime),

        };
        private static readonly HashSet<Type> BoolTypes = new()
        {
            typeof(bool),

        };



        internal static string GetQueryBuilderType(this Type type)
        {
            return IntTypes.Contains(type) ||
                   IntTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "number"
                : DoubleTypes.Contains(type) ||
                   DoubleTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "number"
                : DateTypes.Contains(type) ||
                   DateTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "date"
                : BoolTypes.Contains(type) ||
            BoolTypes.Contains(Nullable.GetUnderlyingType(type))
                ? "boolean"
                : "string";
        }


        public static IEnumerable<DbParameter> MapToParameters(this List<QueryBuilderFilter>? filters, string dbType)
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
