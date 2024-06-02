using Data.Data.ARTDGAML;
using Data.FCF71;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace Data.Data.SASAml
{
    public class SasAmlContext : DbContext
    {
        //AML
        public virtual DbSet<ArtHomeAlertsPerDate> ArtHomeAlertsPerDates { get; set; } = null!;

        public virtual DbSet<ArtHomeAlertsPerStatus> ArtHomeAlertsPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtHomeNumberOfAccount> ArtHomeNumberOfAccounts { get; set; } = null!;
        public virtual DbSet<ArtHomeNumberOfCustomer> ArtHomeNumberOfCustomers { get; set; } = null!;
        public virtual DbSet<ArtHomeNumberOfHighRiskCustomer> ArtHomeNumberOfHighRiskCustomers { get; set; } = null!;
        public virtual DbSet<ArtHomeNumberOfPepCustomer> ArtHomeNumberOfPepCustomers { get; set; } = null!;
        public virtual DbSet<ArtAmlTriageView> ArtAmlTriageViews { get; set; } = null!;
        public virtual DbSet<ArtAmlAlertDetailView> ArtAmlAlertDetailViews { get; set; } = null!;
        public virtual DbSet<ArtAmlCustomersDetailsView> ArtAmlCustomersDetailsViews { get; set; } = null!;
        public virtual DbSet<ArtAmlCaseDetailsView> ArtAmlCaseDetailsViews { get; set; } = null!;
        public virtual DbSet<ArtAmlHighRiskCustView> ArtAmlHighRiskCustViews { get; set; } = null!;
        public virtual DbSet<ArtRiskAssessmentView> ArtRiskAssessmentViews { get; set; } = null!;
        public virtual DbSet<BigData> BigDatas { get; set; } = null!;

        public SasAmlContext(DbContextOptions<SasAmlContext> opt) : base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //AML
            modelBuilder.Entity<ArtStAlertPerOwner>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAlertsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerCategory>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerPriority>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerSubcat>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCustPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCustPerRisk>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCustPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlPropRiskClass>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlRiskClass>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlAlertAgeSummery>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlAlertsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlAlertsPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStAmlAlertsPerScenario>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerBranch>().HasNoKey().ToView(null);


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAmlModelCreating(modelBuilder);
        }

        public IEnumerable<T> ExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            return this.Database.IsSqlServer()
                ? this.SqlServerExecuteProc<T>(SPName, parameters)
                : this.Database.IsOracle() ? this.OracleExecuteProc<T>(SPName, parameters) : Enumerable.Empty<T>();
        }

        private IEnumerable<T> SqlServerExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            string sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
            return this.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        private IEnumerable<T> OracleExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            DbParameter? output = parameters.FirstOrDefault(x => x.Direction == ParameterDirection.Output) ?? throw new NullReferenceException("there is no output parameter");
            DbCommand command = this.Database.GetDbConnection().CreateCommand();
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
            this.Database.OpenConnection();


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
            this.Database.CloseConnection();
            return result;

        }
    }
}
