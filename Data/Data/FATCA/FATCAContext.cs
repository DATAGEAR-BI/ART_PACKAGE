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


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFATCAModelCreating(modelBuilder);
            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
