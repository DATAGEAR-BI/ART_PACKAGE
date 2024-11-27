using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGECMFilters
{
    public partial class DGECMFiltersContext : DbContext
    {
        public DGECMFiltersContext()
        {
        }

        public DGECMFiltersContext(DbContextOptions<DGECMFiltersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtCaseStatusFilterTb> ArtCaseStatusFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCaseTypeFilterTb> ArtCaseTypeFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtActionFilterTb> ArtActionFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtSanctionSensitivityActionNameFilterTb> ArtSanctionSensitivityActionNameFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtSanctionSensitivityCategoryFilterTb> ArtSanctionSensitivityCategoryFilterTbs { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGECMFiltersModelCreating(modelBuilder);
        }


    }
}
