using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGCFTWL
{
    public partial class DGCFTWLContext : DbContext
    {
        public DGCFTWLContext()
        {
        }

        public DGCFTWLContext(DbContextOptions<DGCFTWLContext> options)
            : base(options)
        {
        }
        public virtual DbSet<FscEntityWatchListDim> FscEntityWatchListDims { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGCFTWLModelCreating(modelBuilder);
        }


    }
}
