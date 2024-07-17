using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.GOAML
{
    public partial class GoAmlContext : DbContext
    {
        public GoAmlContext()
        {
        }

        public GoAmlContext(DbContextOptions<GoAmlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportIndicatorType> ReportIndicatorTypes { get; set; } = null!;
        public virtual DbSet<Taccount> Taccounts { get; set; } = null!;
        public virtual DbSet<Lookup> Lookups { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnGoAmlModelCreating(modelBuilder);


        }


    }
}
