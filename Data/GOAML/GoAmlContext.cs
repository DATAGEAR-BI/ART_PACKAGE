using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.GOAML
{
    public partial class GoAmlContext : TenatDBContext
    {
     

        public GoAmlContext(DbContextOptions<GoAmlContext> options, ITenantService tenantService)
      : base(options, tenantService)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "GOAMLContextConnection");
        }


        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportIndicatorType> ReportIndicatorTypes { get; set; } = null!;
        public virtual DbSet<Taccount> Taccounts { get; set; } = null!;
        public virtual DbSet<Lookup> Lookups { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnGoAmlModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);



        }


    }
}
