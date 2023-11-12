using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.CRP
{
    public class CRPContext : DbContext
    {
        public virtual DbSet<ArtCrpCase> ArtCrpCases { get; set; } = null!;
        public virtual DbSet<ArtCrpSystemPerformance> ArtCrpSystemPerformances { get; set; } = null!;
        public virtual DbSet<ArtCrpUserPerformance> ArtCrpUserPerformances { get; set; } = null!;


        public CRPContext(DbContextOptions<CRPContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ART_ST_CRP_PER_STATUS>().HasNoKey().ToView(null);
            modelBuilder.Entity<ART_ST_CRP_PER_RISK>().HasNoKey().ToView(null);


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnCRPModelCreating(modelBuilder);
        }
    }
}
