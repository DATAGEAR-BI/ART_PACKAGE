using Data.Data.Segmentation;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTGOAML
{
    public class ArtGoAmlContext :DbContext
    {



        public ArtGoAmlContext(DbContextOptions<ArtGoAmlContext> options)
      : base(options)
        {
        }

        //GOAML
        public virtual DbSet<ArtGoamlReportsIndicator> ArtGoamlReportsIndicators { get; set; } = null!;
        public virtual DbSet<ArtGoamlReportsDetail> ArtGoamlReportsDetails { get; set; } = null!;
        public virtual DbSet<ArtGoamlReportsSusbectParty> ArtGoamlReportsSusbectParties { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTGOAMLModelCreating(modelBuilder);
        }
        public IEnumerable<T> ExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            if (this.Database.IsSqlServer())
                return this.SqlServerExecuteProc<T>(SPName, parameters);
            if (this.Database.IsOracle())
                return this.OracleExecuteProc<T>(SPName, parameters);
            return Enumerable.Empty<T>();
        }

        private IEnumerable<T> SqlServerExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            var sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
            return this.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        private IEnumerable<T> OracleExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            var output = parameters.FirstOrDefault(x => x.Direction == ParameterDirection.Output);
            if (output is null)
                throw new NullReferenceException("there is no output parameter");

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(output);
            foreach (var param in parameters)
            {
                if (param.ParameterName == output.ParameterName)
                    continue;

                command.Parameters.Add(param);
            }
            this.Database.OpenConnection();


            using var reader = command.ExecuteReader();
            var result = new List<T>();
            var properties = typeof(T).GetProperties();
            while (reader.Read())
            {
                var item = Activator.CreateInstance<T>();
                foreach (var property in properties)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        var value = reader[property.Name];
                        property.SetValue(item, value);
                    }
                }
                result.Add(item);
            }
            this.Database.CloseConnection();
            return result;

        }
    }
}
