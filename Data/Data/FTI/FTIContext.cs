using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

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

        public FTIContext(DbContextOptions<FTIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFTIModelCreating(modelBuilder);
        }
    }
}
