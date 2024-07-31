using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGECM
{
    public partial class DGECMContext : DbContext
    {
        public DGECMContext()
        {
        }

        public DGECMContext(DbContextOptions<DGECMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefTableVal> RefTableVals { get; set; } = null!;
        public virtual DbSet<CaseLive> CaseLives { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGECMModelCreating(modelBuilder);
        }


    }
}
