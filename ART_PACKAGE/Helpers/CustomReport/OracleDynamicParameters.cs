using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ART_PACKAGE.Helpers
{

    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new();

        private readonly List<OracleParameter> oracleParameters = new();

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            OracleParameter oracleParameter = size.HasValue
                ? new OracleParameter(name, oracleDbType, size.Value, value, direction)
                : new OracleParameter(name, oracleDbType, value, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            OracleParameter oracleParameter = new(name, oracleDbType, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);


            if (command is OracleCommand oracleCommand)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }
    }
}
