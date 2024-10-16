using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.FCFKC.SASAML
{
    public class FCFKC : TenatDBContext
    {
        public FCFKC(DbContextOptions<FCFKC> options, ITenantService tenantService)
      : base(options, tenantService)
        {

        }
        public virtual DbSet<FskLov> FskLovs { get; set; } = null!;
        public virtual DbSet<FskRiskAssessment> FskRiskAssessments { get; set; } = null!;
        public virtual DbSet<FskScenario> FskScenarios { get; set; } = null!;
        public virtual DbSet<FskCase> FskCases { get; set; } = null!;
        public virtual DbSet<FskQueue> FskQueues { get; set; } = null!;
        public virtual DbSet<Fsk_EntityQueue> FskEntityQueues { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "FCFKCContextConnection");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnFcfkcSASAMLModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }
    }
}
