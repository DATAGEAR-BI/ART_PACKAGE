using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.Audit.DGMGMT
{
    public partial class DGMGMTContext : TenatDBContext
    {

        public DGMGMTContext(DbContextOptions<DGMGMTContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        public virtual DbSet<GroupDg> GroupDgs { get; set; } = null!;
        public virtual DbSet<RoleDg> RoleDgs { get; set; } = null!;
        public virtual DbSet<UserDg> UserDgs { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGMGMTContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGMGMGModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }


    }
}
