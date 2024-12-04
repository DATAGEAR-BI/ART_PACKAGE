using Data.DGECMFilters;
using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGAMLAdmin
{
    public partial class DGAMLAdminContext : DbContext
    {
        public DGAMLAdminContext()
        {
        }

        public DGAMLAdminContext(DbContextOptions<DGAMLAdminContext> options)
            : base(options)
        {
        }


        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var modelCreatingStrategy = new ModelCreatingContext(new ModelCreatingStrategyFactory(this).CreateModelCreatingStrategyInstance());
            modelCreatingStrategy.OnDGAMLAdminModelCreating(modelBuilder);
        }


    }
}
