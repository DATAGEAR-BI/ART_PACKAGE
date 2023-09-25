using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGAML
{
    public partial class DGAMLContext : DbContext
    {
        public DGAMLContext()
        {
        }

        public DGAMLContext(DbContextOptions<DGAMLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcLkpTable> AcLkpTables { get; set; } = null!;
        public virtual DbSet<AcRoutine> AcRoutines { get; set; } = null!;
        public virtual DbSet<AcScenarioEvent> AcScenarioEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<ExternalCustomer> ExternalCustomers { get; set; } = null!;

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<AcRoutineParameter> AcRoutineParameters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDgAMLModelCreating(modelBuilder);
        }


    }
}
