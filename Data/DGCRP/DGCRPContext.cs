using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGCRP
{
    public partial class DGCRPContext : DbContext
    {
        public DGCRPContext()
        {
        }

        public DGCRPContext(DbContextOptions<DGCRPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtCrpActionFilterTb> ArtCrpActionFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCrpCaseStatusFilter> ArtCrpCaseStatusFilters { get; set; } = null!;
        public virtual DbSet<ArtCrpCaseTypeFilter> ArtCrpCaseTypeFilters { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGCRPModelCreating(modelBuilder);
        }


    }
}
