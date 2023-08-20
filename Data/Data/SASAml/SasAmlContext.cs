using Data.FCF71;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

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

        public SasAmlContext(DbContextOptions<SasAmlContext> opt) : base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnSasAmlModelCreating(modelBuilder);
        }
    }
}
