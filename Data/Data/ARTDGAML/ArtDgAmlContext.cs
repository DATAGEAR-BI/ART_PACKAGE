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

            modelBuilder.Entity<ArtStDgAmlAlarmsPerStatus>().HasNoKey().ToView(null);
            modelBuilder.Entity<ArtStDgAmlTotalAlarmsDetail>().HasNoKey().ToView(null);


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTDGAMLModelCreating(modelBuilder);
        }

    }
}
//Scaffold-DbContext "Server=192.168.1.182;Database=ART_DB;User=root;Password=P@ssw0rd;" MySql.EntityFrameworkCore -Tables ART_DGAML_CASE_DETAIL_VIEW, ART_DGAML_ALERT_DETAIL_VIEW, ART_DGAML_CUSTOMER_DETAIL_VIEW, ART_DGAML_TRIAGE_VIEW, ART_EXTERNAL_CUSTOMER_DETAIL_VIEW, ART_SCENARIO_ADMIN_VIEW, ART_SCENARIO_HISTORY_VIEW, ART_SUSPECT_DETAIL_VIEW, ART_HOME_DGAML_ALERTS_PER_DATE, ART_HOME_DGAML_ALERTS_PER_STATUS, ART_HOME_DGAML_NUMBER_OF_ACCOUNTS, ART_HOME_DGAML_NUMBER_OF_CUSTOMERS, ART_HOME_DGAML_NUMBER_OF_HIGH_RISK_CUSTOMERS, ART_HOME_DGAML_NUMBER_OF_PEP_CUSTOMERS -OutputDir Models -Context YourDbContextName -Force