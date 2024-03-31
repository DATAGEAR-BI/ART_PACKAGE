using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Data.Services.DbContextExtentions
{
    public static class ProcExtention
    {
        public static IEnumerable<T> ExecuteProc<T>(this DbContext db, string SPName, params DbParameter[] parameters) where T : class
        {
            return db.Database.IsSqlServer()
                ? db.SqlServerExecuteProc<T>(SPName, parameters)
                : db.Database.IsOracle() ? db.OracleExecuteProc<T>(SPName, parameters) : Enumerable.Empty<T>();
        }

        private static IEnumerable<T> SqlServerExecuteProc<T>(this DbContext db, string SPName, params DbParameter[] parameters) where T : class
        {
            string sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
            return db.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        private static IEnumerable<T> OracleExecuteProc<T>(this DbContext db, string SPName, params DbParameter[] parameters) where T : class
        {
            DbParameter? output = parameters.FirstOrDefault(x => x.Direction == ParameterDirection.Output) ?? throw new NullReferenceException("there is no output parameter");
            DbCommand command = db.Database.GetDbConnection().CreateCommand();
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            _ = command.Parameters.Add(output);
            foreach (DbParameter param in parameters)
            {
                if (param.ParameterName == output.ParameterName)
                {
                    continue;
                }

                _ = command.Parameters.Add(param);
            }
            db.Database.OpenConnection();


            using DbDataReader reader = command.ExecuteReader();
            List<T> result = new();
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
            while (reader.Read())
            {
                T item = Activator.CreateInstance<T>();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        object value = reader[property.Name];
                        property.SetValue(item, value);
                    }
                }
                result.Add(item);
            }
            db.Database.CloseConnection();
            return result;

        }
    }
}
