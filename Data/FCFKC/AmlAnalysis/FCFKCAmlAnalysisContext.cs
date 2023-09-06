using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.FCFKC.AmlAnalysis
{
    public class FCFKCAmlAnalysisContext : DbContext
    {
        //aml_analysis
        public virtual DbSet<FskAlert> FskAlerts { get; set; } = null!;
        public virtual DbSet<FskAlertEvent> FskAlertEvents { get; set; } = null!;
        public virtual DbSet<FskAlertedEntity> FskAlertedEntities { get; set; } = null!;
        public virtual DbSet<FskComment> FskComments { get; set; } = null!;
        public virtual DbSet<FskEntityEvent> FskEntityEvents { get; set; } = null!;
        public virtual DbSet<FskEntityQueue> FskEntityQueues { get; set; } = null!;

        public FCFKCAmlAnalysisContext(DbContextOptions<FCFKCAmlAnalysisContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFcfkcAmlAnalysisModelCreating(modelBuilder);
        }
    }
}
