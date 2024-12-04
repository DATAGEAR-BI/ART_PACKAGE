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
        public virtual DbSet<ArtDgAmlCasePriorityFilterTb> ArtDgAmlCasePriorityFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtDgAmlCaseStatusFilterTb> ArtDgAmlCaseStatusFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtDgAmlCaseCategoryFilterTb> ArtDgAmlCaseCategoryFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtDgAmlEntityLevelFilterTb> ArtDgAmlEntityLevelFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerIdentificationTypeFilterTb> ArtCustomerIdentificationTypeFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerRiskClassificationFilterTb> ArtCustomerRiskClassificationFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerIndustryFilterTb> ArtCustomerIndustryFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerOccupationFilterTb> ArtCustomerOccupationFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerStatusFilterTb> ArtCustomerStatusFilterTbs { get; set; } = null!;
        public virtual DbSet<ArtCustomerCityFilterTb> ArtCustomerCityFilterTbs { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGAMLFiltersModelCreating(modelBuilder);
        }


    }
}
