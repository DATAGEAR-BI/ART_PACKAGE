using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Data.DGFATCA
{
    public partial class DGFATCAContext : TenatDBContext
    {

        public DGFATCAContext(DbContextOptions<DGFATCAContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGFATCAContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGFATCAModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
