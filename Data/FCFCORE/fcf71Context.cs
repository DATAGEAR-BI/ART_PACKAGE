using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFCORE
{
    public partial class fcf71Context : DbContext
    {
        public fcf71Context()
        {
        }

        public fcf71Context(DbContextOptions<fcf71Context> options)
            : base(options)
        {
        }
        public virtual DbSet<FscPartyDim> FscPartyDims { get; set; } = null!;
        public virtual DbSet<FscBranchDim> FscBranchDims { get; set; } = null!;

        public virtual DbSet<FscBankDim> FscBankDims { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFCFCOREModelCreating(modelBuilder);

        }


    }
}
