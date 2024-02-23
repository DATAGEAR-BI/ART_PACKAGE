using Data.Data.FATCA;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DATA.FATCA
{
    public partial class FATCAContext : DbContext
    {
        public FATCAContext()
        {
        }

        public FATCAContext(DbContextOptions<FATCAContext> options)
            : base(options)
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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=ART;Password=ART1;Data Source=192.168.1.70:1521/orcl;");
            }
        }

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
            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
