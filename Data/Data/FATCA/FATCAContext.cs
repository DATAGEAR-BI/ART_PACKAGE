using Data.Data.FATCA;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.FATCA
{
    public partial class FATCAContext : TenatDBContext
    {
      
        public FATCAContext(DbContextOptions<FATCAContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<ArtFatcaAlert> ArtFatcaAlerts { get; set; } = null!;
        public virtual DbSet<ArtFatcaCace> ArtFatcaCaces { get; set; } = null!;
        public virtual DbSet<ArtFatcaCustomer> ArtFatcaCustomers { get; set; } = null!;
        public virtual DbSet<ArtFatcaDormantAccountsSummary> ArtFatcaDormantAccountsSummaries { get; set; } = null!;
        public virtual DbSet<ArtFatcaIrsReport> ArtFatcaIrsReports { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_ALERTS_PER_BRANCH> ART_ST_FATCA_ALERTS_PER_BRANCH { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_CASES_PER_BRANCH> ART_ST_FATCA_CASES_PER_BRANCH { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_ALERTS_PER_TYPE> ART_ST_FATCA_ALERTS_PER_TYPE { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_CASES_PER_TYPE> ART_ST_FATCA_CASES_PER_TYPE { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_CUSTS_PER_NATION> ART_ST_FATCA_CUSTS_PER_NATION { get; set; } = null!;
        public virtual DbSet<ART_ST_FATCA_CASES_PER_STATUS> ART_ST_FATCA_CASES_PER_STATUS { get; set; } = null!;




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ART_ST_FATCA_ALERTS_PER_BRANCH>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_FATCA_CASES_PER_BRANCH>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_FATCA_ALERTS_PER_TYPE>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_FATCA_CASES_PER_TYPE>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_FATCA_CUSTS_PER_NATION>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_FATCA_CASES_PER_STATUS>().HasNoKey().ToView(null);


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFATCAModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
