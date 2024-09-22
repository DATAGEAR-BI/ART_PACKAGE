using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGWLLOGS
{
    public partial class DGWLLOGSContext : DbContext
    {
        public DGWLLOGSContext()
        {
        }

        public DGWLLOGSContext(DbContextOptions<DGWLLOGSContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGWLLOGSModelCreating(modelBuilder);
        }


    }
}
