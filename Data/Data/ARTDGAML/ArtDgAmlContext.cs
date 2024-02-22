using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.ARTDGAML
{
    public class ArtDgAmlContext : DbContext
    {
        public ArtDgAmlContext(DbContextOptions<ArtDgAmlContext> options)
      : base(options)
        {
        }

        //DGAML
        public virtual DbSet<ArtDgAmlCaseDetailView> ArtDgAmlCaseDetailViews { get; set; } = null!;
        public virtual DbSet<ArtDgAmlAlertDetailView> ArtDGAMLAlertDetailViews { get; set; } = null!;
        public virtual DbSet<ArtDgAmlCustomerDetailView> ArtDGAMLCustomerDetailViews { get; set; } = null!;
        public virtual DbSet<ArtDgAmlTriageView> ArtDGAMLTriageViews { get; set; } = null!;
        public virtual DbSet<ArtExternalCustomerDetailView> ArtExternalCustomerDetailViews { get; set; } = null!;
        public virtual DbSet<ArtScenarioAdminView> ArtScenarioAdminViews { get; set; } = null!;
        public virtual DbSet<ArtScenarioHistoryView> ArtScenarioHistoryViews { get; set; } = null!;
        public virtual DbSet<ArtSuspectDetailView> ArtSuspectDetailViews { get; set; } = null!;
        //DGAML Home
        public virtual DbSet<ArtHomeDgamlAlertsPerDate> ArtHomeDgamlAlertsPerDates { get; set; } = null!;
        public virtual DbSet<ArtHomeDgamlAlertsPerStatus> ArtHomeDgamlAlertsPerStatuses { get; set; } = null!;
        public virtual DbSet<ArtHomeDgamlNumberOfAccount> ArtHomeDgamlNumberOfAccounts { get; set; } = null!;
        public virtual DbSet<ArtHomeDgamlNumberOfCustomer> ArtHomeDgamlNumberOfCustomers { get; set; } = null!;
        public virtual DbSet<ArtHomeDgamlNumberOfHighRiskCustomer> ArtHomeDgamlNumberOfHighRiskCustomers { get; set; } = null!;
        public virtual DbSet<ArtHomeDgamlNumberOfPepCustomer> ArtHomeDgamlNumberOfPepCustomers { get; set; } = null!;
        public virtual DbSet<ArtAlertsCommentsPopupView> ArtAlertsCommentsPopupViews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //DGAML
            modelBuilder.Entity<ArtStDgAmlAlertPerOwner>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCustomerPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCustomerPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCasesPerCategory>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCasesPerPriority>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlCasesPerStatus>().HasNoKey().ToView(null);

            modelBuilder.Entity<ArtStDgAmlExternalCustomerPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlExternalCustomerPerType>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerBranch>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlAlertsPerScenario>().HasNoKey().ToView(null);

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTDGAMLModelCreating(modelBuilder);
        }

    }
}
