using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.DGECM
{
    public partial class DGECMContext : TenatDBContext
    {
       

        public DGECMContext(DbContextOptions<DGECMContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<RefTableVal> RefTableVals { get; set; } = null!;
        public virtual DbSet<CaseLive> CaseLives { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGECMContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGECMModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }


    }
}
