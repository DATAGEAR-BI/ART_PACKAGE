using Data.Data;
using Data.ModelCreatingStrategies;
using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Data.DGAMLCORE
{
    public partial class DGAMLCOREContext : TenatDBContext
    {


        public DGAMLCOREContext(DbContextOptions<DGAMLCOREContext> options,ITenantService tenantService)
      : base(options, tenantService)
        {
        }

       /* public virtual DbSet<AcLkpTable> AcLkpTables { get; set; } = null!;
        public virtual DbSet<AcRoutine> AcRoutines { get; set; } = null!;
        public virtual DbSet<AcScenarioEvent> AcScenarioEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;*/
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<ExternalCustomer> ExternalCustomers { get; set; } = null!;

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        //public virtual DbSet<AcRoutineParameter> AcRoutineParameters { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            contextBuilder(optionsBuilder, "DGAMLCOREContextConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDgAMLCOREModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }


    }
}
