using Data.Constants.db;
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
            Dictionary<string, StoredParam> paramtersDictionary = new()
            {

                { "startdate",new(){

                    SqlServerName="@V_START_DATE",
                    OracleName="V_START_DATE",
                    MySqlName="V_START_DATE",
                    SqlServerType=SqlDbType.Date,
                    OracleType = OracleDbType.Varchar2,
                    MySqlType = MySqlDbType.Date,
                  }
                },
                { "enddate",new(){
                    SqlServerName="@V_END_DATE",
                    OracleName="V_END_DATE",
                    MySqlName="V_END_DATE",
                    SqlServerType=SqlDbType.Date,
                    OracleType = OracleDbType.Varchar2,
                    MySqlType = MySqlDbType.Date
                }},
                { "customer_number",new(){
                    SqlServerName="@CUSTOMER_NUMBER",
                    OracleName="CUSTOMER_NUMBER",
                    MySqlName="CUSTOMER_NUMBER",
                    SqlServerType=SqlDbType.VarChar,
                    OracleType = OracleDbType.Varchar2,
                    MySqlType = MySqlDbType.VarChar

                }},
                { "scenarioname",new(){
                    SqlServerName="@V_scenario_name",
                    OracleName="V_scenario_name",
                    MySqlName="V_scenario_name",
                    SqlServerType=SqlDbType.VarChar,
                    OracleType = OracleDbType.Varchar2,
                    MySqlType = MySqlDbType.VarChar

                }},
                { "year",new(){
                    SqlServerName="@V_YEAR",
                    OracleName="V_YEAR",
                    MySqlName="V_YEAR",
                    SqlServerType=SqlDbType.VarChar,
                    OracleType = OracleDbType.Varchar2,
                    MySqlType = MySqlDbType.VarChar

                }},
            };
            return dbType switch
            {
                DbTypes.SqlServer => filters.Select(x =>
                {
                    return
                    new SqlParameter((paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].SqlServerName : x.id), paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].SqlServerType : SqlDbType.VarChar) { Value = x.value };
                }),
                DbTypes.Oracle => filters.Select(x => new OracleParameter(paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].OracleName : x.id, paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].OracleType : OracleDbType.Varchar2, ParameterDirection.Input) { Value = x.value }).Append(new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)),
                DbTypes.MySql => filters.Select(x =>
                {
                    return
                    new MySqlParameter((paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].MySqlName : x.id), paramtersDictionary.ContainsKey(x.id) ? paramtersDictionary[x.id].MySqlType : MySqlDbType.VarChar) { Value = x.value };
                }),
                _ => Enumerable.Empty<DbParameter>(),

            };
        }
    }
    public class StoredParam
    {
        public string SqlServerName { get; set; }
        public string OracleName { get; set; }
        public string MySqlName { get; set; }
        public OracleDbType OracleType { get; set; }
        public SqlDbType SqlServerType { get; set; }
        public MySqlDbType MySqlType { get; set; }
    }
}