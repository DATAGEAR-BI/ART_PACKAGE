using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFCORE
{
    public partial class fcf71Context : TenatDBContext
    {

        public fcf71Context(DbContextOptions<fcf71Context> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }
        public virtual DbSet<FscPartyDim> FscPartyDims { get; set; } = null!;
        public virtual DbSet<FscBranchDim> FscBranchDims { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "FCFCOREContextConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFCFCOREModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);


        }


    }
}
