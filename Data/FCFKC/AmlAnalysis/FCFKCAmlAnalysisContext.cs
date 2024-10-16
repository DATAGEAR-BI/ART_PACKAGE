using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFKC.AmlAnalysis
{
    public class FCFKCAmlAnalysisContext : TenatDBContext
    {
        //aml_analysis
        public virtual DbSet<FskAlert> FskAlerts { get; set; } = null!;
        public virtual DbSet<FskAlertEvent> FskAlertEvents { get; set; } = null!;
        public virtual DbSet<FskAlertedEntity> FskAlertedEntities { get; set; } = null!;
        public virtual DbSet<FskComment> FskComments { get; set; } = null!;
        public virtual DbSet<FskEntityEvent> FskEntityEvents { get; set; } = null!;
        public virtual DbSet<FskEntityQueue> FskEntityQueues { get; set; } = null!;

        public FCFKCAmlAnalysisContext(DbContextOptions<FCFKCAmlAnalysisContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "FCFKCContextConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFcfkcAmlAnalysisModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
    }
}
