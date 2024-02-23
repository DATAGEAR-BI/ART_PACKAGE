using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Data.DGFATCA
{
    public partial class DGFATCAContext : DbContext
    {
        public DGFATCAContext()
        {
        }

        public DGFATCAContext(DbContextOptions<DGFATCAContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGFATCAModelCreating(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
