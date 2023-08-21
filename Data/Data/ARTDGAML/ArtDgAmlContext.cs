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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnARTDGAMLModelCreating(modelBuilder);
        }

    }
}
