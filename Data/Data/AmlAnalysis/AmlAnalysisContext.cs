using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.AmlAnalysis
{
    public class AmlAnalysisContext : DbContext
    {
        public virtual DbSet<ArtAmlAnalysisView> ArtAmlAnalysisViews { get; set; } = null!;
        public virtual DbSet<ArtAmlAnalysisViewTb> ArtAmlAnalysisViewTbs { get; set; } = null!;
        public virtual DbSet<ArtAmlAnalysisRule> ArtAmlAnalysisRules { get; set; } = null!;

        public AmlAnalysisContext(DbContextOptions<AmlAnalysisContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dbtype = this.Database.IsSqlServer() ? "sqlserver" : this.Database.IsOracle() ? "oracle" : "";
            modelBuilder.ApplyConfiguration(new ArtAmlAnalysisRuleConfigration(dbtype));
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnAmlAnalysisModelCreating(modelBuilder);
        }
    }
}
