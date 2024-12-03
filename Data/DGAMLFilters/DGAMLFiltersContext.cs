using Data.DGECMFilters;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGAMLFilters
{
    public partial class DGAMLFiltersContext : DbContext
    {
        public DGAMLFiltersContext()
        {
        }

        public DGAMLFiltersContext(DbContextOptions<DGAMLFiltersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtMoneyLaunderingRiskScoreFilterTb> ArtMoneyLaunderingRiskScoreFilterTbs { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGAMLFiltersModelCreating(modelBuilder);
        }


    }
}
