using Data.Data.SASAml;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;

namespace Data.Data.FTI
{
    public class FTIContext : DbContext
    {
        //// FTI
        //public virtual DbSet<ArtTiAcpostingsAccReport> ArtTiAcpostingsAccReports { get; set; } = null!;
        //public virtual DbSet<ArtTiAcpostingsCustReport> ArtTiAcpostingsCustReports { get; set; } = null!;
        //public virtual DbSet<ArtTiActivityReport> ArtTiActivityReports { get; set; } = null!;
        //public virtual DbSet<ArtTiAmortizationReport> ArtTiAmortizationReports { get; set; } = null!;
        //public virtual DbSet<ArtTiChargesByCustReport> ArtTiChargesByCustReports { get; set; } = null!;
        //public virtual DbSet<ArtTiChargesByMasterReport> ArtTiChargesByMasterReports { get; set; } = null!;
        //public virtual DbSet<ArtTiChargesDetailsReport> ArtTiChargesDetailsReports { get; set; } = null!;
        //public virtual DbSet<ArtTiDiaryExceptionsReport> ArtTiDiaryExceptionsReports { get; set; } = null!;
        //public virtual DbSet<ArtTiEcmTransactionsReport> ArtTiEcmTransactionsReports { get; set; } = null!;
        //public virtual DbSet<ArtTiInterfaceDetailsReport> ArtTiInterfaceDetailsReports { get; set; } = null!;
        //public virtual DbSet<ArtTiMasterEventHistory> ArtTiMasterEventHistories { get; set; } = null!;
        //public virtual DbSet<ArtTiMastevehistProdFilter> ArtTiMastevehistProdFilters { get; set; } = null!;
        //public virtual DbSet<ArtTiMastevehistStatusFilter> ArtTiMastevehistStatusFilters { get; set; } = null!;
        //public virtual DbSet<ArtTiOsActivityReport> ArtTiOsActivityReports { get; set; } = null!;
        //public virtual DbSet<ArtTiOsLiabilityReport> ArtTiOsLiabilityReports { get; set; } = null!;
        //public virtual DbSet<ArtTiOsTransAwaitiApprlReport> ArtTiOsTransAwaitiApprlReports { get; set; } = null!;
        //public virtual DbSet<ArtTiOsTransByGatewayReport> ArtTiOsTransByGatewayReports { get; set; } = null!;
        //public virtual DbSet<ArtTiOsTransByNonpriReport> ArtTiOsTransByNonpriReports { get; set; } = null!;
        //public virtual DbSet<ArtTiOsTransByPrincipalReport> ArtTiOsTransByPrincipalReports { get; set; } = null!;
        //public virtual DbSet<ArtTiPeriodicChrgsPayReport> ArtTiPeriodicChrgsPayReports { get; set; } = null!;
        //public virtual DbSet<ArtTiPeriodicChrgsReport> ArtTiPeriodicChrgsReports { get; set; } = null!;
        //public virtual DbSet<ArtTiSystemTailoringReport> ArtTiSystemTailoringReports { get; set; } = null!;
        //public virtual DbSet<ArtTiWatchlistOsCheckReport> ArtTiWatchlistOsCheckReports { get; set; } = null!;
        //public virtual DbSet<ArtTiFinanInterAccrual> ArtTiFinanInterAccruals { get; set; } = null!;
        //public virtual DbSet<ArtTiAdvancePaymentUtilizationReport> ArtTiAdvancePaymentUtilizationReports { get; set; } = null!;
        //public virtual DbSet<ArtTiEcmWorkflowProgReport> ArtTiEcmWorkflowProgReports { get; set; } = null!;
        //public virtual DbSet<ArtTiFullJournalReport> ArtTiFullJournalReports { get; set; } = null!;
        //public virtual DbSet<ArtTiEcmWorkflowProgReportOld> ArtTiEcmWorkflowProgReportOlds { get; set; } = null!;
        //public virtual DbSet<ArtTiEcmAuditReport> ArtTiEcmAuditReports { get; set; } = null!;

        //ABK
        public virtual DbSet<ArtCasesInitiatedFromBranch> ArtCasesInitiatedFromBranches { get; set; } = null!;
        public virtual DbSet<ArtDgecmActivity> ArtDgecmActivities { get; set; } = null!;
        public virtual DbSet<ArtEcmFtiFullCycle> ArtEcmFtiFullCycles { get; set; } = null!;
        public virtual DbSet<ArtFtiActivity> ArtFtiActivities { get; set; } = null!;
        public virtual DbSet<ArtFtiEcmTransaction> ArtFtiEcmTransactions { get; set; } = null!;
        public virtual DbSet<ArtFtiEndToEnd> ArtFtiEndToEnds { get; set; } = null!;

        public FTIContext(DbContextOptions<FTIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//[ART_DB].[ART_ST_CASES_YEAR_TO_YEAR]
            modelBuilder.Entity<ArtStCasesYearToYear>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerProduct>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStCasesPerDate>().HasNoKey().ToView(null);
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFTIModelCreating(modelBuilder);
        }

        public IEnumerable<T> ExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            return this.Database.IsSqlServer()
                ? this.SqlServerExecuteProc<T>(SPName, parameters)
                : this.Database.IsOracle() ? this.OracleExecuteProc<T>(SPName, parameters) : Enumerable.Empty<T>();
        }

        private IEnumerable<T> SqlServerExecuteProc<T>(string SPName, params DbParameter[] parameters) where T : class
        {
            try
            {
                string sql = $"EXEC {SPName} {string.Join(", ", parameters.Select(x => x.ParameterName))}";
                return this.Set<T>().FromSqlRaw(sql, parameters).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(SPName+" - "+e.ToString());
                throw ;
            }
            
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
